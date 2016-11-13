using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using RabbitMQ.ServiceModel;

namespace ClientApp
{
    class Options
    {

      

        [Option(longName:"Action", HelpText = "Specifies what action sould be performed. \"Publish\" will publish files to the specified IpAddress. \"Consume\" will consume files from the specified IpAddress ")]
        public String Action { get; set; }

        [Option(longName: "QueueName", HelpText = "Specifies which queue to connect to.")]
        public String QueueName { get; set; }

        [Option(longName: "UserName", HelpText = "UserName to connect as")]
        public String UserName { get; set; }

        [Option(longName: "Password", HelpText = "Password for the user account")]
        public String Password { get; set; }

        [Option(longName: "IpAddress", HelpText = "Ip address of the RabbitMQ server.")]
        public String IpAddress { get; set; }

        [Option(longName: "VirtualHost", HelpText = "Specifies which virtual host to connect to. Default is \"\\\"")]
        public String VirtualHost { get; set; }

        [Option(longName: "PersistentQueue", HelpText = "Persistent queues transcend server shutdowns and are available when the servers come back up.")]
        public bool PersistentQueue { get; set; }

        [Option(longName: "PersistentMessages", HelpText = "Persistence messages are stored on disk.")]
        public bool PersistentMessages { get; set; }

        [Option(longName: "BindingKey", HelpText = "Sepcifies binding key for message routing. Check RabbitMQ documentation for explanations.")]
        public String BindingKey { get; set; }

        [Option(longName: "FilePaths", HelpText = "Path to the files to be published to queue.")]
        public string[] FilePaths { get; set; }

        [Option(longName: "ConfirmsEnabled", HelpText = "")]
        public bool ConfirmsEnabled { get; set; }

        [Option(longName: "MandatoryEnabled", HelpText = "")]
        public String MandatoryEnabled { get; set; }

        [Option(longName: "PublishCount", HelpText = "")]
        public int Count { get; set; }

        [Option(longName: "MessageExpiration", HelpText = "")]
        public String MessageExpiration { get; set; }

        [Option(longName: "MessageAcknowledge", HelpText = "Applies if selected action is \"consume\" ")]
        public bool MessageAcknowledge { get; set; }
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }


    }
}
