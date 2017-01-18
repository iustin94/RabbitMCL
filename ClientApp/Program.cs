using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using ClientApp.Model;
using ClientApp.Service;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using CommandLine;

namespace ClientApp
{
    class Program
    {
        private static ConnectionManager _connectionMngr;

        public static void Main(string[] args)
        {
            var parser = new Parser(with =>
            {
                with.CaseSensitive = false;
                with.HelpWriter = Console.Out;
                with.IgnoreUnknownArguments = true;
            });

            var options = new Options();

            string invokedVerb = String.Empty;
            object invokedVerbInstance = null;


            if (!parser.ParseArguments(args, options,
            (verb, subOptions) =>
                {
                    // if parsing succeeds the verb name and correct instance
                    // will be passed to onVerbCommand delegate (string,object)
                    invokedVerb = verb;
                    invokedVerbInstance = subOptions;
                }))
            {
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }

            if (invokedVerb == "Consume")
            {       
                    var consumeSubOptions = (ConsumeSubOptions)invokedVerbInstance;
                    Consume(consumeSubOptions);
            }

            if (invokedVerb == "Publish")
            {
                
                    var publishSubOptions = (PublishSubOptions)invokedVerbInstance;
                    Publish(publishSubOptions);            
            }


            Console.ReadLine();
        }

        private static void Publish(PublishSubOptions options)
        {
                if (options.FilePaths == null)
                    options.FilePaths = ConsoleManager.GetFilePaths().ToArray();

                var watch = System.Diagnostics.Stopwatch.StartNew();
                double avrgLength = 0;
                double minLength = 0;
                double maxLength = 0;

                List<String> messages = new List<String>();

                foreach (string f in options.FilePaths)
                {
                    string fileText = System.IO.File.ReadAllText(f);
                    messages.Add(fileText);
                }

                avrgLength = (int)messages.Average(x => x.Length);
                maxLength = (int)messages.Max(x => x.Length);
                minLength = (int)messages.Min(x => x.Length);

                _connectionMngr = ConnectionManager.GetInstance();

                _connectionMngr.SetConnectionCredentials(Username: options.UserName,
                    Password: options.Password,
                    Virtualhost: options.VirtualHost,
                    Ip: options.Ip,
                    Hosts: options.Hosts
                );

                using (var connection = _connectionMngr.Connection)
                using (var channel = _connectionMngr.Channel)
                {

                    TopologyManager.DeclareTopology(channel: channel, options: options);

                    if (options.ConfirmsEnabled)
                    {
                        channel.ConfirmSelect();
                    }

                    IBasicProperties props = GenerateMessageProperties(channel, options.PersistentMessages);

                    if (options.Count > 0)
                        PublishWithCount(channel, props, options.Count, messages, options);
                    else
                        PublishUntilStop(channel, props, messages, options);
                }

                ConsoleManager.PrintParameters(options, watch, maxLength, minLength, avrgLength);

                Console.ReadLine();
           
        }

        private static IBasicProperties GenerateMessageProperties(IModel channel, bool PersistentMessages)
        {

            IBasicProperties props = channel.CreateBasicProperties();

            props.Persistent = PersistentMessages;
            //props.Headers = new Dictionary<string, object>();
            //props.Headers.Add("Timestamp", DateTime.Now);
            //props.Headers.Add("Location", "Aarhus , Denmark");

            return props;
        }

        private static void PublishUntilStop(IModel channel, IBasicProperties props, List<string> messages, PublishSubOptions options)
        {
            ConsoleManager.AnnouncePublishingStarted();

            do
            {
                while (!Console.KeyAvailable)
                {
                    foreach (var messageBody in messages)
                    {
                        var body = Encoding.UTF8.GetBytes(messageBody);

                        try
                        {
                            channel.BasicPublish(exchange: options.QueueName + "-Exchange",
                                routingKey: options.BindingKey,
                                basicProperties: props,
                                body: body,
                                mandatory: true);
                            if (options.ConfirmsEnabled)
                                channel.WaitForConfirmsOrDie();
                        }
                        catch (Exception ex)
                        {
                           
                            ConsoleManager.PrintException(ex);

                            try
                            {
                                channel.BasicPublish(exchange: options.QueueName + "fallback",
                                    routingKey: options.BindingKey,
                                    basicProperties: props,
                                    body: body,
                                    mandatory: true);
                                if (options.ConfirmsEnabled)
                                    channel.WaitForConfirmsOrDie();
                            }
                            catch (Exception ex2)
                            {
                                ConsoleManager.PrintException(ex2);
                            }
                            
                        }
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }




        private static void PublishWithCount(IModel channel, IBasicProperties props, int count, List<String> messages, PublishSubOptions options)
        {
            for (int i = 0; i <= options.Count; i++)
            {

                foreach (var messageBody in messages)
                {
                    var body = Encoding.UTF8.GetBytes(messageBody);

                    channel.BasicPublish(exchange: options.ExchangeName,
                        routingKey: options.BindingKey,
                        basicProperties: props,
                        body: body,
                        mandatory: true);
                    if (options.ConfirmsEnabled)
                        channel.WaitForConfirmsOrDie();
                }
            }
        }

        private static void Consume(ConsumeSubOptions options)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            double avrgLength = 0;
            double maxLength = 0;
            double minLength = 0;

            var factory = new ConnectionFactory()
            {
                HostName = options.Ip,
                UserName = options.UserName,
                Password = options.Password,
                VirtualHost = options.VirtualHost
            };

            _connectionMngr = ConnectionManager.GetInstance();

            _connectionMngr.SetConnectionCredentials(Username: options.UserName,
               Password: options.Password,
               Virtualhost: options.VirtualHost,
               Ip: options.Ip,
               Hosts: options.Hosts
                );

            using (var connection = _connectionMngr.Connection)
            using (var channel = _connectionMngr.Channel)
            {
                //channel.BasicQos(1000, 5000, true);


                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    options.PersistentMessages = ea.BasicProperties.Persistent;
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;

                    if (avrgLength == 0)
                    {
                        avrgLength = body.Length;
                    }
                    else
                    {
                        avrgLength = (avrgLength + body.Length) / 2;
                    }

                    if (body.Length < minLength)
                        minLength = body.Length;
                    if (body.Length > maxLength)
                        maxLength = body.Length;

                    if (options.MessageAcknowledge)
                    {
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                };

                channel.BasicConsume(queue: options.QueueName,
                    noAck: !options.MessageAcknowledge,
                    consumer: consumer);


                Console.WriteLine();
                Console.ReadKey();

                channel.Close();
                connection.Close();
            }

            watch.Stop();
            ConsoleManager.PrintParameters(options, watch, maxLength, minLength, avrgLength);

        }

        public static void ReadLine(IModel channel, IConnection connection)
        {
            if (Console.ReadLine().ToLower().Trim() == "Stop")
            {
                channel.Close();
                connection.Close();
            }
            else
                ReadLine(channel, connection);
        }
    }
}
