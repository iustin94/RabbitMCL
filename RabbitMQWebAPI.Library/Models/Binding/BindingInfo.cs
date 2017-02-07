using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Binding;

namespace RabbitMQWebApi.Library.Models.Binding
{
    /// <summary>
    /// Container for information on Bindings entity retrieved from the RabbitAPI.
    /// </summary>
    public class BindingInfo
    {
        readonly string source;
        readonly string vhost;
        readonly string destination;
        readonly string destination_type;
        readonly string routing_key;
        readonly IDictionary<string, string> arguments;
        readonly string properties_key;

    
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
    }
}
