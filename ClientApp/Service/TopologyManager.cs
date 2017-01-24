using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Model;
using ClientApp.Service;
using RabbitMQ.Client;

namespace ClientApp
{
     static class TopologyManager
    {
        public static void DeclareTopology(IModel channel, PublishSubOptions options)
        {

            try
            {
     
                channel.ExchangeDeclare(exchange: options.ExchangeName + "-MainExchange",
                    autoDelete: false,
                    type: "topic",
                    durable: options.PersistentExchange,
                    arguments: null
                );

                channel.ExchangeDeclare(exchange: options.ExchangeName + "-alternativeExchange",
                    autoDelete: false,
                    type: "topic",
                    durable: options.PersistentExchange,
                    arguments: null
                );

                channel.QueueDeclare(queue: options.QueueName + "-Fallback",
                    autoDelete: false,
                    durable: options.PersistentQueue,
                    exclusive: false,
                    arguments: null);

                channel.QueueDeclare(queue: options.QueueName,
                    autoDelete: false,
                    durable: options.PersistentQueue,
                    exclusive: false,
                    arguments: null);

                channel.QueueBind(queue: options.QueueName,
                    exchange: options.ExchangeName + "-MainExchange",
                    routingKey: options.BindingKey,
                    arguments: null);

                channel.QueueBind(queue: options.QueueName + "-Fallback",
                    exchange: options.ExchangeName + "-alternativeExchange",
                    routingKey: options.BindingKey,
                    arguments: null);

                options.ExchangeName += "-MainExchange";
            }
            catch (Exception ex)
            {
                ConsoleManager.PrintException(ex);
                Console.ReadKey();

                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }
        }
    }
}
