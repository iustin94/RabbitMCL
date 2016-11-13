using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Framing.Impl;
using CommandLine;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    class Program
    {


        delegate void ConsumeDelegate(Options options);

        static void Main(string[] args)
        {
            try
            {


                var options = new Options();
                if (CommandLine.Parser.Default.ParseArguments(args, options))
                {
                    
                    if (options.Method == "Consume")
                    { Consume(options); }
                    else
                    {
                        throw new ArgumentNullException("Method",
                            " The method parameter does not match any available option." +
                            "You have the following options:" +
                            "Consume");
                    }

                }
                else
                {
                    Console.Write("Could not parse arguments");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write(ex.StackTrace);
                Console.ReadLine();
            }
        }

      
        private static void Consume(Options options)
        {
            try
            {

                var watch = System.Diagnostics.Stopwatch.StartNew();
                double avrgLength = 0;
                double maxLength = 0;
                double minLength = 0;

                var factory = new ConnectionFactory()
                {
                    HostName = options.Hostname,
                    UserName = options.Username,
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
                        options.Persistent = ea.BasicProperties.Persistent;
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

                        if (body.Length < minLength) minLength = body.Length;
                        if (body.Length > maxLength) maxLength = body.Length;

                        if (options.Ack) { channel.BasicAck(ea.DeliveryTag, false); }
                    };
                   
                    channel.BasicConsume(queue: options.QueueName,
                                         noAck: !options.Ack,                              // Sets if the server will wait for acknowledgements before deleting message
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
            else ReadLine(channel, connection);
        }

        public static void PrintParameters(Options options, Stopwatch watch, double maxLength, double minLength, double avrgLength)
        {
            Console.Write("Process has ended: \n" +
                          "\n\tConnection parameters:" +
                          "\n\t\tQueue name: " + options.QueueName +
                          "\n\t\tUsername: " + options.Username +
                          "\n\t\tPassword: " + options.Password +
                          "\n\t\tVirtual host: " + options.VirtualHost +
                          "\n\t\tServer address: " + options.Hostname +
                          "\n\n" +
                          "\n\tTransmision parameters:" +
                          "\n\t\tExecuted action: " + options.Method +
                          "\n\t\tElapsed miliseconds" + watch.ElapsedMilliseconds +
                          "\n\t\tAcknowledgements: " + (options.Ack ? "Enabled" : "Dissabled") +
                          "\n\t\tMessage persistence: " + (options.Persistent ? "Enabled" : "Dissabled") +
                          "\n\t\tMaximum message length: " + maxLength +
                          "\n\t\tMinimum message length: " + minLength +
                          "\n\t\tAverage message length: " + avrgLength);
        }

    }
}

