using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace ClientApp.Model
{
    class Options
    {
        public Options()
        {
            
        }

        [VerbOption("Consume", HelpText = "Consume files from IpAddress")]
        public ConsumeSubOptions ConsumeVerb { get; set; }


        [VerbOption("Publish", HelpText = "Publish files to IpAddress")]
        public PublishSubOptions PublishVerb { get; set; }
    }
}
