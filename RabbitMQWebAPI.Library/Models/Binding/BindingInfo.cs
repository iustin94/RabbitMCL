using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Binding;

namespace RabbitMQWebApi.Library.Models.Binding
{
    /// <summary>
    /// Container for information on Bindings entity retrieved from the RabbitAPI.
    /// </summary>
    public class BindingInfo
    {
        public string source { private set; get; }
        public string vhost { private set; get; }
        public string destination { private set; get; }
        public string destination_type { private set; get; }
        public string routing_key { private set; get; }
        public IDictionary<string, string> arguments { private set; get; }
        public string properties_key { private set; get; }

        /// <summary>
        /// The class constructor.
        /// </summary>
        public BindingInfo(BindingInfoParameters parameters)
        {
            this.arguments = parameters.arguments;
            this.destination = parameters.destination;
            this.destination_type = parameters.destination_type;
            this.properties_key = parameters.properties_key;
            this.routing_key = parameters.routing_key;
            this.source = parameters.source;
            this.vhost = parameters.vhost;
        }

        public BindingInfo() { }
    }
}
