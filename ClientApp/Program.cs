using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using ClientApp.Model;
using ClientApp.Service;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using CommandLine;
using RabbitDataAccess = RabbitMQWebAPI.Library;
using RabbitMQWebAPI.Library.Models;
using RabbitMQWebAPI.Library.Models.Exchange;
using RabbitMQWebAPI.Library.Models.Queue;
using RabbitMQWebAPI.Library.Service;

namespace ClientApp
{
    class Program
    {
        private static ConnectionManager _connectionMngr;

        public static void Main(string[] args)
        {

            System.Threading.Thread.CurrentThread.Name = "Main thread";

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
            try
            {
                if (options.FilePaths == null)
                    options.FilePaths = ConsoleManager.GetFilePaths().ToArray();

                Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
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

                _connectionMngr.CreateFactory(Username: options.UserName,
                    Password: options.Password,
                    Virtualhost: options.VirtualHost,
                    Ip: options.Ip,
                    Hosts: options.Hosts);

                using (var connection = _connectionMngr.CreateConnection(options.Hosts))
                using (var channel = connection.CreateModel())
                {

                    TopologyManager.DeclareTopology(channel: channel, options: options);

                    connection.ConnectionBlocked += (sender, args) =>
                    {
                        Console.WriteLine("Connection State: Blocked \n");
                    };

                    connection.ConnectionShutdown += (sender, args) =>
                    {
                        Console.WriteLine("Connection State: Shutdown \n");
                    };

                    connection.ConnectionUnblocked += (sender, args) =>
                    {
                        Console.WriteLine("Connection State: Unblocked \n");
                    };

                    connection.ConnectionShutdown += (sender, args) =>
                    {
                        Console.WriteLine("Connection State: Shutdown," + args.Cause + ", " + ", " + args.ReplyText +
                                          ", " + args.Initiator);
                    };

                    connection.CallbackException += (sender, args) =>
                    {
                        Console.WriteLine("Connection State: callback exception");
                    };

                    if (options.ConfirmsEnabled)
                    {
                        channel.ConfirmSelect();
                        channel.WaitForConfirmsOrDie();
                    }

                    IBasicProperties props = GenerateMessageProperties(channel, options.PersistentMessages);

                    if (options.Count > 0)
                        PublishWithCount(channel, props, options.Count, messages, options);
                    else

                        PublishUntilStop(channel, props, messages, options);
                }

                ConsoleManager.PrintParameters(options, watch, maxLength, minLength, avrgLength);

            }
            catch (Exception ex)
            {
                ConsoleManager.PrintException(ex);
            }
        }

        private static IBasicProperties GenerateMessageProperties(IModel channel, bool persistentMessages)
        {

            IBasicProperties props = channel.CreateBasicProperties();

            props.Persistent = persistentMessages;

            return props;
        }

        private static void PublishUntilStop(IModel channel, IBasicProperties props, List<string> messages, PublishSubOptions options)
            {
            IEnumerable<RabbitMQWebAPI.Library.Models.Queue.QueueInfo> latestQueueInfo = new List<QueueInfo>();

            IDictionary<string, State.StateEnum> queueStatuses = new Dictionary<string, State.StateEnum>();


            Thread queueInfoPoolingThread = new Thread(() =>
           {
               do
               {
                   lock (queueStatuses)
                   {
                       try
                       {
                           queueStatuses = new Dictionary<string, State.StateEnum>();
                           var queues = new RabbitDataAccess.DataAccess.Queues();
                           var latestQueueInfos = queues.GetQueueInfos().Result;

                           foreach (QueueInfo q in latestQueueInfos)
                           {
                              //??
                           }

                       }
                       catch (Exception ex)
                       {
                           ConsoleManager.PrintException(ex);
                       }
                   }
                   Thread.Sleep(15000);

               } while (true);
           });

            queueInfoPoolingThread.Name = "Queue Info Pooling Thread";
            queueInfoPoolingThread.IsBackground = true;
            queueInfoPoolingThread.Start();

            ExchangesQueues excahngesQueuesFactory = new ExchangesQueues();

            ExchangeInfo ei1 = excahngesQueuesFactory.getExchangeForQueue("ha.queue1").Result;
            ExchangeInfo ei2 = excahngesQueuesFactory.getExchangeForQueue("ha.queue1-Fallback").Result;

            ConsoleManager.AnnouncePublishingStarted();

            while (!Console.KeyAvailable)
            {
                foreach (var messageBody in messages)
                {
                    var body = Encoding.UTF8.GetBytes(messageBody);

                    try
                    {
                        

                        if (queueStatuses.ContainsKey("ha.queue1") &&
                            queueStatuses["ha.queue1"] != State.StateEnum.Syncing)
                        {
                            channel.BasicPublish(exchange: ei1.name,
                            routingKey: options.BindingKey,
                            basicProperties: props,
                            body: body,
                            mandatory: true);
                        }
                        else if (queueStatuses.ContainsKey("ha.queue1-Fallback") &&
                                 queueStatuses["ha.queue1-Fallback"] != State.StateEnum.Syncing)
                        {
                            channel.BasicPublish(exchange: ei2.name,
                            routingKey: options.BindingKey,
                            basicProperties: props,
                            body: body,
                            mandatory: true);
                        }

                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        ConsoleManager.PrintException(ex);

                        if (options.ExchangeName.EndsWith("-MainExchange"))
                        {
                            options.ExchangeName = options.ExchangeName.Remove(options.ExchangeName.Length - 13);
                            options.ExchangeName = options.ExchangeName + "-alternativeExchange";
                        }
                        else
                        {
                            options.ExchangeName = options.ExchangeName.Remove(options.ExchangeName.Length - 20);
                            options.ExchangeName = options.ExchangeName + "-MainExchange";
                        }
                    }

                    catch (Exception ex)
                    {
                        ConsoleManager.PrintException(ex);
                    }
                }
            }

            queueInfoPoolingThread.Abort();

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

            _connectionMngr = ConnectionManager.GetInstance();

            _connectionMngr.CreateFactory(Username: options.UserName,
               Password: options.Password,
               Virtualhost: options.VirtualHost,
               Ip: options.Ip,
               Hosts: options.Hosts
                );

            using (var connection = _connectionMngr.Factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

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
            }

            watch.Stop();
            ConsoleManager.PrintParameters(options, watch, maxLength, minLength, avrgLength);

        }
    }
}
