using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using ClientApp.Model;
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
            try
            {

                var options = new Options();

                string invokedVerb = String.Empty;
                object invokedVerbInstance = null;


                if( !CommandLine.Parser.Default.ParseArguments(args, options,

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

                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();

                    
                }


                if (invokedVerb == "Consume")
                {
                    try
                    {
                        var consumeSubOptions = (ConsumeSubOptions) invokedVerbInstance;
                        Consume(consumeSubOptions);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (invokedVerb == "Publish")
                {
                    try
                    {
                        var publishSubOptions = (PublishSubOptions) invokedVerbInstance;
                        Publish(publishSubOptions);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "\n");
                Console.Write(ex.StackTrace);
                Console.Read();
            }

        }

        private static void Publish(PublishSubOptions options)
        {
            //To-Do validate fields

            try
            {
                if (options.FilePaths == null)
                    options.FilePaths = GetFilePaths();

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
                    IpAddresses: options.IpAddresses,
                    Port: options.Port);

                _connectionMngr.CicleToFirstOrNextHost();

                // Will the connection and channel be copied in the using block? Or will they get transfered. Will there still be connection in the _connectionMngr?
                using (var connection = _connectionMngr.Connection)
                using (var channel = _connectionMngr.Channel)
                {
                    channel.ExchangeDeclare(exchange: options.QueueName,
                        type: "topic",
                        durable: options.PersistentQueue);

                    // Delete the queue after all consumers are finished. If there was no consumer, it won't be deleted
                    // Makes queue persist after a server restart.
                    // Makes queue exclusive. No other connection can access it while the current connection is running.
                    // Set of arguments for the declaration. The syntax depends on the server.
                    channel.QueueDeclare(queue: options.QueueName,
                        autoDelete: false,
                        durable: options.PersistentQueue,
                        exclusive: false,
                        arguments: null);

                    if (options.ConfirmsEnabled)
                    {
                        channel.ConfirmSelect();
                    }

                    channel.QueueBind(queue: options.QueueName,
                        exchange: options.QueueName,
                        routingKey: options.BindingKey,
                        arguments: null);

                    IBasicProperties props = GenerateMessageProperties(channel, options.PersistentMessages);

                    if (options.Count > 0)
                        PublishWithCount(channel, props, options.Count, messages, options);
                    else
                        PublishUntilStop(channel, props, messages, options);

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

        private static IBasicProperties GenerateMessageProperties(IModel channel, bool PersistentMessages)
        {

            IBasicProperties props = channel.CreateBasicProperties();

            // Sets delivery mode of message to persistent or non-persistent
            props.Persistent = PersistentMessages;

            //props.Headers = new Dictionary<string, object>();
            //props.Headers.Add("Timestamp", DateTime.Now);
            //props.Headers.Add("Location", "Aarhus , Denmark");

            return props;
        }

        private static void PublishUntilStop(IModel channel, IBasicProperties props, List<string> messages, PublishSubOptions options)
        {
            Console.WriteLine("Publishing in course. Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    foreach (var messageBody in messages)
                    {
                        var body = Encoding.UTF8.GetBytes(messageBody);

                        channel.BasicPublish(exchange: options.QueueName,
                            routingKey: options.BindingKey,
                            basicProperties: props,
                            body: body,
                            mandatory: true);
                        if (options.ConfirmsEnabled)
                            channel.WaitForConfirmsOrDie();
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
            try
            {

                var watch = System.Diagnostics.Stopwatch.StartNew();
                double avrgLength = 0;
                double maxLength = 0;
                double minLength = 0;

                var factory = new ConnectionFactory()
                {
                    HostName = options.Hostname,
                    UserName = options.UserName,
                    Password = options.Password,
                    VirtualHost = options.VirtualHost
                };

                _connectionMngr = ConnectionManager.GetInstance();

                _connectionMngr.SetConnectionCredentials(Username: options.UserName,
                   Password: options.Password,
                   Virtualhost: options.VirtualHost,
                   IpAddresses: options.IpAddresses,
                   Port: options.Port);

                _connectionMngr.CicleToFirstOrNextHost();

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
                        // Sets if the server will wait for acknowledgements before deleting message
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

        /// <summary>
        /// First checks if there the string is null or empty. If not then checks for file at given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool FileExistsAt(string path)
        {

            if (!String.IsNullOrEmpty(path) && System.IO.File.Exists(path))
            {
                return true;
            }

            return false;
        }

        // BAD CODE. Showld have base options class with common parameters and separate child classes with the different extra parameters.
        public static void PrintParameters(PublishSubOptions options, Stopwatch watch, double maxLength,
            double minLength, double avrgLength)
        {
            Console.Write("\n" +
                          "Process has ended: " +
                          "\n\tConnection parameters:" +
                          "\n\t\tQueue name: " + options.QueueName +
                          "\n\t\tUsername: " + options.UserName +
                          "\n\t\tPassword: " + options.Password +
                          "\n\t\tVirtual host: " + options.VirtualHost +
                          "\n\t\tServer address: " + options.Hostname +
                          "\n\n" +
                          "\n\tTransmision parameters: " +
                          "\n\t\tExecuted action: " + "Publish" +
                          "\n\t\tElapsed miliseconds: " + watch.ElapsedMilliseconds +
                          "\n\t\tMessage confirmations: " + (options.ConfirmsEnabled ? "Enabled" : "Disabled") +
                          "\n\t\tMessage persistence: " + (options.PersistentMessages ? "Enabled" : "Disabled") +
                          "\n\t\tMaximum message length: " + maxLength +
                          "\n\t\tMinimum message length: " + minLength +
                          "\n\t\tAverage message length: " + avrgLength);
        }

        public static void PrintParameters(ConsumeSubOptions options, Stopwatch watch, double maxLength,
            double minLength, double avrgLength)
        {
            Console.Write("\n" +
                          "Process has ended: " +
                          "\n\tConnection parameters:" +
                          "\n\t\tQueue name: " + options.QueueName +
                          "\n\t\tUsername: " + options.UserName +
                          "\n\t\tPassword: " + options.Password +
                          "\n\t\tVirtual host: " + options.VirtualHost +
                          "\n\t\tServer address: " + options.Hostname +
                          "\n\n" +
                          "\n\tTransmision parameters: " +
                          "\n\t\tExecuted action: " + "Publish" +
                          "\n\t\tElapsed miliseconds: " + watch.ElapsedMilliseconds +
                          "\n\t\tMessage persistence: " + (options.PersistentMessages ? "Enabled" : "Disabled") +
                          "\n\t\tMaximum message length: " + maxLength +
                          "\n\t\tMinimum message length: " + minLength +
                          "\n\t\tAverage message length: " + avrgLength);
        }

        public static void PrintErrors(IEnumerable<ParsingError> errors)
        {
            foreach (var err in errors)
            {
                Console.WriteLine(err.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Read paths to file by command line
        /// </summary>
        /// <returns></returns>
        public static List<String> GetFilePaths()
        {

            List<String> paths = new List<string>();

            bool keyIsValid = false;

            Console.WriteLine(
                "\nFor single file publishing press A. For multiple file publishing press B. To exit press ctl+c.");

            while (!keyIsValid)
            {

                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.A)
                {

                    ClearConsoleBuffer();
                    keyIsValid = true;

                    Console.WriteLine("\n\nEnter path to file: ");


                    //Loop to get a good file from the user. If path is empty or null it reprompts for file input.
                    bool pathIsEmpty = true;
                    while (pathIsEmpty)
                    {
                        string path = Console.ReadLine();

                        if (String.IsNullOrEmpty(path))
                        {
                            Console.WriteLine("\n You have not entered a valid path. The application will exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        else if (FileExistsAt(path))
                        {
                            pathIsEmpty = false;
                            paths.Add(path);
                        }
                        else
                        {
                            Console.WriteLine("\nFile could not be found. Try again. ");

                            ClearConsoleBuffer();
                        }
                    }
                }

                else if (key == ConsoleKey.B)
                {
                    ClearConsoleBuffer();
                    keyIsValid = true;
                    Console.WriteLine("\n\nEnter path to file: ");

                    bool finished = false;
                    while (!finished)
                    {
                        string path = Console.ReadLine();
                        if (String.IsNullOrEmpty(path))
                        {
                            finished = true;
                        }
                        else if (FileExistsAt(path))
                        {
                            paths.Add(path);
                        }
                        else
                        {
                            Console.Write("\nThe path does not point to a file. Try again or press ctrl+c to exit.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nThe key you have entered is invalid. Please try again.");
                    ClearConsoleBuffer();
                }
            }

            if (paths.Count <= 0)
            {
                Console.WriteLine("\n You have not entered any file path. The application will now exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return paths;
        }
        public static void ClearConsoleBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(false);
        }

    }
}
