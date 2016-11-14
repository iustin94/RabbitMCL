using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace Producer

{
    static class Options
    {

        [Verb("Publish", HelpText = "Publish files to IpAddress")]
        class PublishSubOptions
        {
            [Option(longName: "QueueName", HelpText = "")]
            public String QueueName { get; set; }

            [Option(longName: "UserName", HelpText = "")]
            public String UserName { get; set; }

            [Option(longName: "Password", HelpText = "")]
            public String Password { get; set; }

            [Option(longName: "IpAddress", HelpText = "")]
            public String IpAddress { get; set; }

            [Option(longName: "VirtualHost", HelpText = "")]
            public String VirtualHost { get; set; }

            [Option(longName: "PersistentQueue", HelpText = "")]
            public bool PersistentQueue { get; set; }

            [Option(longName: "PersistentMessages", HelpText = "")]
            public bool PersistentMessages { get; set; }

            [Option(longName: "BindingKey", HelpText = "")]
            public String BindingKey { get; set; }

            [Option(longName: "FilePaths", HelpText = "")]
            public String FilePaths { get; set; }


            [Option(longName: "ConfirmsEnabled", HelpText = "")]
            public String ConfirmsEnabled { get; set; }

            [Option(longName: "MandatoryEnabled", HelpText = "")]
            public String MandatoryEnabled { get; set; }

            [Option(longName: "PublishCount", HelpText = "")]
            public int Count { get; set; }

            public string GetUsage()
            {
                // this without using CommandLine.Text
                //  or using HelpText.AutoBuild
                var usage = new StringBuilder();
                usage.AppendLine("Quickstart Application 1.0");
                usage.AppendLine("Read user manual for usage instructions...");
                return usage.ToString();
            }

        }

        [Verb("Consume", HelpText = "Conusme files from IpAddress")]
        class ConsumeSuboption
        {

            [Option(longName: "QueueName", HelpText = "")]
            public String QueueName { get; set; }

            [Option(longName: "UserName", HelpText = "")]
            public String UserName { get; set; }

            [Option(longName: "Password", HelpText = "")]
            public String Password { get; set; }

            [Option(longName: "IpAddress", HelpText = "")]
            public String IpAddress { get; set; }

            [Option(longName: "VirtualHost", HelpText = "")]
            public String VirtualHost { get; set; }

            [Option(longName: "PersistentQueue", HelpText = "")]
            public bool PersistentQueue { get; set; }

            [Option(longName: "PersistentMessages", HelpText = "")]
            public bool PersistentMessages { get; set; }

            [Option(longName: "BindingKey", HelpText = "")]
            public String BindingKey { get; set; }

            public string GetUsage()
            {
                // this without using CommandLine.Text
                //  or using HelpText.AutoBuild
                var usage = new StringBuilder();
                usage.AppendLine("Quickstart Application 1.0");
                usage.AppendLine("Read user manual for usage instructions...");
                return usage.ToString();
            }
        }
        ///*               CustomPropertiesParameters                */

        //[Option(longName:"CustomProperties", HelpText ="If custom options are enabled the following parameters must be provided: \r\n\t\t" +
        //                                             "-persistent: bool \r\n\t\t\t"+
        //                                             "-expiration: string \r\n\t\t\t")]
        //public bool CustomProperties { get; set; }

        //[Option(longName:"CustomHeaders", HelpText="Enable sending of custom headers. Custom headers are hardcoded.")]
        //public bool CustomHeaders { get; set; }

        //[Option(longName:"Expiration", HelpText = "sets the expiration time of the message after publishing. To be set in milliseconds")]
        //public string Expiration { get; set; }   

        //[Option(longName:"Priority", HelpText = "Set the message priority on a scale of 0 to 9")]
        //public byte Priority { get; set; }

        //[Option(longName: "Persistance", HelpText = "Queue persistance setting")]
        //public bool Persistance { get; set; }

        ///*           Basic parameters               */

        //[Option(shortName:'m', longName:"Method", HelpText="Determines the type of producing that will be done to the queue."+
        //                                    "The following options are available:"+
        //                                    "Not yet implemented")]
        //public string Method { get; set; }

        //[Option(shortName:'u', longName:"Username", HelpText = "Username that will be used to connect to the rabbitMQ server. Default value is guesst if used on localhost." +
        //                                 "For LAN connections make sure there is a specific user created in the server and use that user.")]
        //public string Username { get; set; }

        //[Option(shortName: 'p', longName: "Password", HelpText = "User password", Required = true)]
        //public string Password { get; set; }

        //[Option(shortName:'v' , longName:"virtualhost", HelpText = "Virtual host for connection. If left empty the virtual host will be set to \"\\\" ", Required = true)]
        //public string VirtualHost { get; set; }

        //[Option(shortName:'r', longName:"RoutingKey", HelpText = "RoutingKey value. Format \" < speed >.< colour >.< species > \"+" +
        //                                                         "*(star) can substitute for exactly one word;" +
        //                                                         "#(hash) can substitute for zero or more words;"+
        //                                                         "Ex 1: \" *.orange.* \" - Binds the exchange to a queue that has exactly <randomword>.orange.<randomword>"+
        //                                                         "EX 2: \"lazy.# \" - Binds the exchange to queue that has \"lazy.<word>.<word>.<word> ...")]
        //public string RoutingKey { get; set; }

        //[Option(shortName:'c', longName:"Count", HelpText = "Message count for queue ")]
        //public int Count { get; set; }

        //[Option(shortName:'e', longName:"ExchangeName", HelpText = "Name of the exchange to be used.", Required = true)]
        //public string ExchangeName { get; set; }
  
        //[Option(longName:"Confirms", HelpText = "Enable message confirms on published side.")]
        //public bool Confirms { get; set; }

        //[Option(shortName:'h', longName:"Hostname", HelpText = "Hostname of IP address")]
        //public String Hostname { get; set; }

        //[Option(shortName:'q', longName:"QueueName", HelpText = "Name of the queue that the client will connect and send messages too. Make sure that there is a queue on the server with this name.", Required = true)]
        //public String QueueName { get; set; }

        //[Option(longName:"mandatory", HelpText= "This flag tells the server how to react if the message cannot be routed to a queue. If this flag is set, the server will return an unroutable message with a Return method. If this flag is zero, the server silently drops the message.")]
        //public bool Mandatory { get; set; }

        //[Option(longName:"MsgPersistence", HelpText = "This flag tells the server to always write messages to the disk. Normally messages will be written to the disk when the ram memory is overflowing.")]
        //public bool MsgPersistance { get; set; }

        //[Option(longName:"FilesPaths", Separator = ':')]
        //public IEnumerable<string> paths { get; set; }
    }
}
