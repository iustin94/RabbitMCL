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

namespace ClientApp
{
    class Program
    {
        private static ConnectionManager _connectionMngr;

        public QueueInfo latestQueueStatus;

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
            try
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

                _connectionMngr.CreateFactory(Username: options.UserName,
                    Password: options.Password,
                    Virtualhost: options.VirtualHost,
                    Ip: options.Ip,
                    Hosts: options.Hosts
                );



                using (var connection = _connectionMngr.CreateConnection(options.Hosts))
                using (var channel = connection.CreateModel())
                {

                    TopologyManager.DeclareTopology(channel: channel, options: options);

                    connection.ConnectionBlocked += (sender, args) =>
                    {
                        Console.WriteLine("Connection state: Blocked \n");
                    };

                    connection.ConnectionShutdown += (sender, args) =>
                    {
                        Console.WriteLine("Connection state: Shutdown \n");
                    };

                    connection.ConnectionUnblocked += (sender, args) =>
                    {
                        Console.WriteLine("Connection state: Unblocked \n");
                    };

                    connection.ConnectionShutdown += (sender, args) =>
                    {
                        Console.WriteLine("Connection state: Shutdown," + args.Cause + ", " + ", " + args.ReplyText +
                                          ", " + args.Initiator);
                    };

                    connection.CallbackException += (sender, args) =>
                    {
                        Console.WriteLine("Connection state: callback exception");
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
            IEnumerable<QueueInfo> latestQueueInfo = new List<QueueInfo>();
            
            IDictionary<string, bool> queueStatuses = new Dictionary<string, bool>();



            Thread queueInfoPoolingThread = new Thread(() =>
            {
                do
                {
                    latestQueueInfo = RabbitMqHttpApiFacade.GetQueueInfos();

                    foreach (QueueInfo q in latestQueueInfo)
                    {
                        queueStatuses.Add(q.Name, q.State != "Syncing"); //If queue not syncing it means we can publish
                    }

                    Thread.Sleep(15000);
                } while (true);
            });

            queueInfoPoolingThread.Name = "Queue Info Pooling Thread"; 
            queueInfoPoolingThread.IsBackground = true;
            queueInfoPoolingThread.Start();
 
            ConsoleManager.AnnouncePublishingStarted();

            while (!Console.KeyAvailable)
            {
                foreach (var messageBody in messages)
                {
                    var body = Encoding.UTF8.GetBytes(messageBody);

                    try
                    {
                        channel.BasicPublish(exchange: options.ExchangeName,
                            routingKey: options.BindingKey,
                            basicProperties: props,
                            body: body,
                            mandatory: true);

                        System.Threading.Thread.Sleep(100);
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
