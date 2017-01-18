using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Service
{
    static class ConsoleManager
    {

        private const string ConsumerStarted = "";
        private const string PublisherStarted = "\t Publishing in course. Press ESC to stop";
        private const string LeftMargin = "\n\t";

        public static void AnnouncePublishingStarted()
        {
            Console.WriteLine(PublisherStarted);
        }

        public static void AnnounceConsumingStarted()
        {
            Console.WriteLine(ConsumerStarted);
        }

        public static void PrintException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

        }

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
                          "\n\t\tServer address: " + options.Ip +
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
                          "\n\t\tServer address: " + options.Ip +
                          "\n\n" +
                          "\n\tTransmision parameters: " +
                          "\n\t\tExecuted action: " + "Publish" +
                          "\n\t\tElapsed miliseconds: " + watch.ElapsedMilliseconds +
                          "\n\t\tMessage persistence: " + (options.PersistentMessages ? "Enabled" : "Disabled") +
                          "\n\t\tMaximum message length: " + maxLength +
                          "\n\t\tMinimum message length: " + minLength +
                          "\n\t\tAverage message length: " + avrgLength);

        }

        public static List<string> GetFilePaths()
        {

            List<String> paths = new List<string>();

            bool keyIsValid = false;

            Console.WriteLine(
               LeftMargin + "For single file publishing press A. For multiple file publishing press B. To exit press ctl+c.");

            while (!keyIsValid)
            {

                var key = Console.ReadKey().Key;


                if (key == ConsoleKey.A)
                {

                    ClearConsoleBuffer();
                    keyIsValid = true;

                    Console.WriteLine(LeftMargin + "Enter path to file: ");


                    //Loop to get a good file from the user. If path is empty or null it reprompts for file input.
                    bool pathIsEmpty = true;
                    while (pathIsEmpty)
                    {
                        string path = Console.ReadLine();

                        if (String.IsNullOrEmpty(path))
                        {
                            Console.WriteLine(LeftMargin + "You have not entered a valid path. The application will exit.");
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
                            Console.WriteLine(LeftMargin + "File could not be found. Try again. ");

                            ClearConsoleBuffer();
                        }
                    }
                }

                else if (key == ConsoleKey.B)
                {
                    ClearConsoleBuffer();
                    keyIsValid = true;
                    Console.WriteLine(LeftMargin + "Enter path to file: ");

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
                            Console.Write(LeftMargin + "The path does not point to a file. Try again or press ctrl+c to exit.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(LeftMargin + "The key you have entered is invalid. Please try again.");
                    ClearConsoleBuffer();
                }
            }

            if (paths.Count <= 0)
            {
                Console.WriteLine(LeftMargin + "You have not entered any file path. The application will now exit.");
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

        private static bool FileExistsAt(string path)
        {

            if (!String.IsNullOrEmpty(path))
            {
                if (System.IO.File.Exists(path))
                    return true;

                if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + path))
                    return true;
            }

            return false;
        }
    }
}
