using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    class BindingInfo
    {
        public string source;
        public string vhost;
        public string destination;
        public string destination_type;
        public string routing_key;
        public IDictionary<string, string> arguments;
        public string properties_key;

        public BindingInfo(string source,
            string vhost,
            string destination,
            string destination_type,
            string routing_key,
            IDictionary<string, string> arguments,
            string properties_key)
        {
            this.source = source;
            this.vhost = vhost;
            this.destination = destination;
            this.destination_type = destination_type;
            this.routing_key = routing_key;
            this.arguments = arguments;
            this.properties_key = properties_key;
        }

    }
}
