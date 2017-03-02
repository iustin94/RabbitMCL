using System;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using CommandLine;
using CommandLine.Text;

namespace ClientApp.Model
{
    class PublishSubOptions
    {
        [Option(longName: "QueueName", HelpText = "")]
        public String QueueName { get; set; }

        [Option(longName: "ExchangeName", HelpText = "")]
        public String ExchangeName { get; set; }

        [Option(longName: "UserName", HelpText = "")]
        public String UserName { get; set; }

        [Option(longName: "Password", HelpText = "")]
        public String Password { get; set; }

        [Option(longName: "Ip", HelpText = "")]
        public String Ip { get; set; }

        [OptionArray(longName: "Hosts", HelpText = "" )]
        public String[] Hosts { get; set; }

        [Option(longName: "VirtualHost", HelpText = "")]
        public String VirtualHost { get; set; }

        [Option(longName: "Port", HelpText = "")]
        public int Port { get; set; }

        [Option(longName:"PersistentExchange", HelpText = "")]
        public bool PersistentExchange { get; set; }

        [Option(longName: "PersistentQueue", HelpText = "")]
        public bool PersistentQueue { get; set; }

        [Option(longName: "PersistentMessages", HelpText = "")]
        public bool PersistentMessages { get; set; }

        [Option(longName: "BindingKey", HelpText = "")]
        public String BindingKey { get; set; }

        [OptionArray(longName: "File", HelpText = "")]
        public String[] FilePaths { get; set; }

        [Option(longName: "ConfirmsEnabled", HelpText = "")]
        public bool ConfirmsEnabled { get; set; }

        [Option(longName: "MandatoryEnabled", HelpText = "")]
        public String MandatoryEnabled { get; set; }

        [Option(longName:"PublishCount", HelpText = "")]
        public int Count { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

    }
}
