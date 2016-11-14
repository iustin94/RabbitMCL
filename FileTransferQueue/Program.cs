using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using CommandLine;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool ready = false;

                var options = CommandLine.Parser.Default.ParseArguments<Options>(args);
                if (options != null)
                {
                    Console.WriteLine("For single file publishing press A. For multiple file publishing press B");

                    while (!ready)
                    {

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.A)
                        {
                            Console.WriteLine("\n\nEnter path to file: ");
                            string path = Console.ReadLine();
                            if (FileExistsAt(path))
                            {
                                List<String> paths= new List<string>();
                                paths.Add(path);
                            }
                            else
                            {
                                Console.WriteLine("File could not be found. Application will now exit.");
                            }
                            ready = true;
                        }
                        else if (key == ConsoleKey.B)
                        {
                            Console.WriteLine("\n\nEnter path to file: ");
                            List<string> paths = new List<string>();

                            string path = "ALOHA!";
                            while (!String.IsNullOrEmpty(path))
                            {
                                path = Console.ReadLine();
                                if (System.IO.File.Exists(path)) paths.Add(path);

                            }
                            if(paths.Count>0)
                            { options. = paths.ToArray();}
                            ready = true;
                        }
                        else
                        {
                            Console.WriteLine("Seems that something went wrong. Try again? :D");
                        }
                    }

                    if(options.FilesPaths.Length == 0) Console.WriteLine("No file was selected");
                    else if (options.Method == "Publish")
                        Publish(options);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
                Console.ReadLine();
            }
        }

        private static void Publish(Options options)
        {
            try
            {

                var watch = System.Diagnostics.Stopwatch.StartNew();
                double avrgLength = 0;
                double minLength = 0;
                double maxLength = 0;

                List<String> messages = new List<String>();

                foreach (string f in options.FilesPaths)
                {
                    string fileText = System.IO.File.ReadAllText(f);
                    messages.Add(fileText);
                }

                avrgLength = (int)messages.Average(x => x.Length);
                maxLength = (int)messages.Max(x => x.Length);
                minLength = (int)messages.Min(x => x.Length);

                var factory = new ConnectionFactory()
                {
                    HostName = options.Hostname,
                    UserName = options.Username,
                    Password = options.Password,
                    VirtualHost = options.VirtualHost
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    string exchangeName = options.ExchangeName;
                    string queueName = options.QueueName;

                    channel.ExchangeDeclare(exchange: exchangeName,
                        type: "topic",
                        durable: options.Persistance);

                    channel.QueueDeclare(queue: queueName,
                        autoDelete: false, // Delete the queue after all consumers are finished. If there was no consumer, it won't be deleted
                        durable: options.Persistance, // Makes queue persist after a server restart.
                        exclusive: false, // Makes queue exclusive. No other connection can access it while the current connection is running.
                        arguments: null); // Set of arguments for the declaration. The syntax depends on the server.
                    if (options.Confirms)
                    {
                        channel.ConfirmSelect();
                    }

                    channel.QueueBind(queue: queueName,
                        exchange: exchangeName,
                        routingKey: options.RoutingKey,
                        arguments: null);

                    IBasicProperties props = channel.CreateBasicProperties();

                    if (options.CustomProperties)
                    {
                        props.Expiration = options.Expiration;
                        props.Persistent = options.MsgPersistance;              // Sets delivery mode of message to persistent or non-persistent
                        props.Priority = options.Priority;

                        if (options.CustomHeaders)
                        {
                            props.Headers = new Dictionary<string, object>();
                            props.Headers.Add("Timestamp", DateTime.Now);
                            props.Headers.Add("Location", "Aarhus , Denmark");
                        }
                    }

                    if (options.Count > 0)
                    {
                        for (int i = 0; i <= options.Count; i++)
                        {

                            foreach (var messageBody in messages)
                            {
                                var body = Encoding.UTF8.GetBytes(messageBody);

                                channel.BasicPublish(exchange: exchangeName,
                                    routingKey: options.RoutingKey,
                                    basicProperties: props,
                                    body: body,
                                    mandatory: true);
                                if (options.Confirms)
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
                                        routingKey: options.RoutingKey,
                                        basicProperties: props,
                                        body: body);
                                    if (options.Confirms)
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
        private static bool FileExistsAt(string path)
        {

            if (!String.IsNullOrEmpty(path))
            {
                if (System.IO.File.Exists(path))
                {
                    return true;
                }
                else Console.WriteLine("Can't see shit captain! File not present at specified path. Try again.");
            }

            return false;
        }
        public static void ReadLine(IModel channel, IConnection connection)
        {
            if (Console.ReadLine().ToLower().Trim() == "Stop")
            {
                channel.Close();
                connection.Close();
            }
            else ReadLine(channel, connection);
        }

        public static void PrintParameters(Options options, Stopwatch watch, double maxLength, double minLength, double avrgLength)
        {
            Console.Write("\n" +
                          "Process has ended: " +
                          "\n\tConnection parameters:" +
                          "\n\t\tQueue name: " + options.QueueName +
                          "\n\t\tUsername: " + options.Username +
                          "\n\t\tPassword: " + options.Password +
                          "\n\t\tVirtual host: " + options.VirtualHost +
                          "\n\t\tServer address: " + options.Hostname +
                          "\n\n" +
                          "\n\tTransmision parameters: " +
                          "\n\t\tExecuted action: " + options.Method +
                          "\n\t\tElapsed miliseconds: " + watch.ElapsedMilliseconds +
                          "\n\t\tMessage confirmations: " + (options.Confirms? "Enabled" : "Dissabled") +
                          "\n\t\tMessage persistence: " + (options.MsgPersistance ? "Enabled" : "Dissabled") +
                          "\n\t\tMaximum message length: " + maxLength +
                          "\n\t\tMinimum message length: " + minLength +
                          "\n\t\tAverage message length: " + avrgLength);
        }
    }
}
