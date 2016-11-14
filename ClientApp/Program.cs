using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using CommandLine;
namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = Parser.Default.ParseArguments<PublishSubOptions, ConsumeSubOptions>(args)



        }

        private static void Publish(PublishSubOptions options)
        {
            try
            {

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

                var factory = new ConnectionFactory()
                {
                    HostName = options.IpAddress,
                    UserName = options.UserName,
                    Password = options.Password,
                    VirtualHost = options.VirtualHost
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    string exchangeName = options.QueueName;
                    string queueName = options.QueueName;

                    channel.ExchangeDeclare(exchange: exchangeName,
                        type: "topic",
                        durable: options.PersistentMessages);

                    channel.QueueDeclare(queue: queueName,
                        autoDelete: false, // Delete the queue after all consumers are finished. If there was no consumer, it won't be deleted
                        durable: options.PersistentQueue, // Makes queue persist after a server restart.
                        exclusive: false, // Makes queue exclusive. No other connection can access it while the current connection is running.
                        arguments: null); // Set of arguments for the declaration. The syntax depends on the server.
                    if (options.ConfirmsEnabled)
                    {
                        channel.ConfirmSelect();
                    }

                    channel.QueueBind(queue: queueName,
                        exchange: exchangeName,
                        routingKey: options.BindingKey,
                        arguments: null);

                    IBasicProperties props = channel.CreateBasicProperties();

                        props.Persistent = options.PersistentMessages;              // Sets delivery mode of message to persistent or non-persistent

                        props.Headers = new Dictionary<string, object>();
                        props.Headers.Add("Timestamp", DateTime.Now);
                        props.Headers.Add("Location", "Aarhus , Denmark");
                  

                    if (options.Count > 0)
                    {
                        for (int i = 0; i <= options.Count; i++)
                        {

                            foreach (var messageBody in messages)
                            {
                                var body = Encoding.UTF8.GetBytes(messageBody);

                                channel.BasicPublish(exchange: exchangeName,
                                    routingKey: options.BindingKey,
                                    basicProperties: props,
                                    body: body,
                                    mandatory: true);
                                if (options.ConfirmsEnabled)
                                    channel.WaitForConfirmsOrDie();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Publishing in course. Press ESC to stop");
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                foreach (var messageBody in messages)
                                {
                                    var body = Encoding.UTF8.GetBytes(messageBody);

                                    channel.BasicPublish(exchange: exchangeName,
                                        routingKey: options.BindingKey,
                                        basicProperties: props,
                                        body: body);
                                    if (options.ConfirmsEnabled)
                                        channel.WaitForConfirmsOrDie();
                                }
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                    }

                    channel.Close();
                    connection.Close();
                }

                PrintParameters(options, watch, maxLength, minLength, avrgLength);

                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.Write(ex.Message + "\n\t");
                Console.Write(ex.StackTrace);
                Console.ReadLine();
            }
        }

        private static void Consume(ConsumeSubOptions options)
        {
            try
            {

                var watch = System.Diagnostics.Stopwatch.StartNew();
                double avrgLength = 0;
                double maxLength = 0;
                double minLength = 0;

                var factory = new ConnectionFactory()
                {
                    HostName = options.IpAddress,
                    UserName = options.UserName,
                    Password = options.Password,
                    VirtualHost = options.VirtualHost
                };
                factory.AutomaticRecoveryEnabled = true;
                factory.RequestedHeartbeat = 5;
                factory.ContinuationTimeout = new TimeSpan(5000);

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
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
                        { channel.BasicAck(ea.DeliveryTag, false); }
                    };

                    channel.BasicConsume(queue: options.QueueName,
                                         noAck: !options.MessageAcknowledge,                              // Sets if the server will wait for acknowledgements before deleting message
                                         consumer: consumer);


                    Console.WriteLine("Message consumer has started. Press any key to stop consuming.");
                    Console.ReadKey();

                    channel.Close();
                    connection.Close();
                }

                watch.Stop();
                PrintParameters(options, watch, maxLength, minLength, avrgLength);
                Console.ReadKey();


            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
                Console.ReadLine();
            }
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
        private static bool FileExistsAt(string path)
        {

            if (!String.IsNullOrEmpty(path))
            {
                if (System.IO.File.Exists(path))
                {
                    return true;
                }
                else
                    Console.WriteLine("Can't see shit captain! File not present at specified path. Try again.");
            }

            return false;
        }

        // BAD CODE. Showld have base options class with common parameters and separate child classes with the different extra parameters.
        public static void PrintParameters(PublishSubOptions options, Stopwatch watch, double maxLength, double minLength, double avrgLength)
        {
            Console.Write("\n" +
                          "Process has ended: " +
                          "\n\tConnection parameters:" +
                          "\n\t\tQueue name: " + options.QueueName +
                          "\n\t\tUsername: " + options.UserName +
                          "\n\t\tPassword: " + options.Password +
                          "\n\t\tVirtual host: " + options.VirtualHost +
                          "\n\t\tServer address: " + options.IpAddress +
                          "\n\n" +
                          "\n\tTransmision parameters: " +
                          "\n\t\tExecuted action: " + "Publish"+
                          "\n\t\tElapsed miliseconds: " + watch.ElapsedMilliseconds +
                          "\n\t\tMessage confirmations: " + (options.ConfirmsEnabled ? "Enabled" : "Dissabled") +
                          "\n\t\tMessage persistence: " + (options.PersistentMessages ? "Enabled" : "Dissabled") +
                          "\n\t\tMaximum message length: " + maxLength +
                          "\n\t\tMinimum message length: " + minLength +
                          "\n\t\tAverage message length: " + avrgLength);
        }
        public static void PrintParameters(ConsumeSubOptions options, Stopwatch watch, double maxLength, double minLength, double avrgLength)
        {
            Console.Write("\n" +
                          "Process has ended: " +
                          "\n\tConnection parameters:" +
                          "\n\t\tQueue name: " + options.QueueName +
                          "\n\t\tUsername: " + options.UserName +
                          "\n\t\tPassword: " + options.Password +
                          "\n\t\tVirtual host: " + options.VirtualHost +
                          "\n\t\tServer address: " + options.IpAddress +
                          "\n\n" +
                          "\n\tTransmision parameters: " +
                          "\n\t\tExecuted action: " + "Publish" +
                          "\n\t\tElapsed miliseconds: " + watch.ElapsedMilliseconds +
                          "\n\t\tMessage persistence: " + (options.PersistentMessages ? "Enabled" : "Dissabled") +
                          "\n\t\tMaximum message length: " + maxLength +
                          "\n\t\tMinimum message length: " + minLength +
                          "\n\t\tAverage message length: " + avrgLength);
        }
    }
}
