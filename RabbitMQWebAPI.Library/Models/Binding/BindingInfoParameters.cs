using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Binding
{
    public struct BindingInfoParameters
    {
        public string source;
        public string vhost;
        public string destination;
        public string destination_type;
        public string routing_key;
        public IDictionary<string, string> arguments;
        public string properties_key;
    }
}
