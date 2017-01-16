using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Model;
using RabbitMQ.Client;

namespace ClientApp
{
     static class TopologyManager
    {
        public static void DeclareTopology(IModel channel, PublishSubOptions options)
        {
            IDictionary<string, object> args1 = new Dictionary<string, object>();
            args1.Add("alternate-exchange", options.QueueName + "-alternativeExchange");

            IDictionary<string, object> args2 = new Dictionary<string, object>();
            args2.Add("alternate-exchange", options.QueueName + "-Exchange");

            channel.ExchangeDeclare(exchange: options.QueueName + "-alternativeExchange",
                autoDelete: false,
                type: "topic",
                durable: options.PersistentExchange,
                arguments: args2
            );

            channel.ExchangeDeclare(exchange: options.QueueName + "-Exchange",
                autoDelete: false,
                type: "topic",
                durable: options.PersistentExchange,
                arguments: args1
                );

            channel.QueueDeclare(queue: options.QueueName + "fallback",
                autoDelete: false,
                durable: options.PersistentQueue,
                exclusive: false,
                arguments: null);

            channel.QueueDeclare(queue: options.QueueName,
                autoDelete: false,
                durable: options.PersistentQueue,
                exclusive: false,
                arguments: null);

            channel.QueueBind(queue: options.QueueName + "fallback",
                exchange: options.QueueName + "-alternativeExchange",
                routingKey: options.BindingKey,
                arguments: null);

            channel.QueueBind(queue: options.QueueName,
                exchange: options.QueueName + "-Exchange",
                routingKey: options.BindingKey,
                arguments: null);
        }
    }
}
