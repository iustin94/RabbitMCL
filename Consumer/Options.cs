using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;


namespace Consumer
{
    class Options
    {
        [Option(shortName:'m', longName:"method", HelpText = "Method to use for consuming. You have the following options:"+
            "BasicGet , Consume , StartConsuming")]
        public String Method { get; set; }

        [Option(shortName:'q',longName:"queuename", HelpText = "Queue name")]
        public String QueueName { get; set; }

        [Option(longName: "Ack", HelpText = "Message Acknowledge setting")]
        public Boolean Ack { get; set; }

        [Option(shortName:'u', longName: "username", HelpText = "Username that will be used to connect to the rabbitMQ server. Default value is guesst if used on localhost." +
                                                                "For LAN connections make sure there is a specific user created in the server and use that user.")]
        public string Username { get; set; }

        [Option(shortName: 'p', longName: "Password", HelpText = "User password", Required = true)]
        public string Password { get; set; }

        [Option(shortName:'v', longName: "VirtualHost", HelpText = "Input virtualHost", DefaultValue = "/")]
        public string VirtualHost { get; set; }

        [Option(shortName:'h', longName: "address", HelpText = "Host name/Server ip address and port")]
        public string Hostname { get; set; }

        [Option(longName: "Persistent", HelpText = "Queue persistency setting", DefaultValue = false)]
        public bool Persistent { get; set; }

        [Option(shortName:'b', longName: "bindingKey", HelpText = "Bindingkey value. Format \" < speed >.< colour >.< species > \"+" +
                                                                   "*(star) can substitute for exactly one word;" +
                                                                   "#(hash) can substitute for zero or more words;" +
                                                                   "Ex 1: \" *.orange.* \" - Binds the exchange to a queue that has exactly <randomword>.orange.<randomword>" +
                                                                   "EX 2: \"lazy.# \" - Binds the exchange to queue that has \"lazy.<word>.<word>.<word> ...", DefaultValue = "anonimous.info")]
        public string BindingKeys { get; set; }

        [Option(shortName:'c', longName: "Count", HelpText = "Number of times to publish to queue", DefaultValue = 10)]
        public int Count { get; set; }
        
        
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
