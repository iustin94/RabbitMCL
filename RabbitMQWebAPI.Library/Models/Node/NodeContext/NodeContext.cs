using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Node.NodeContext
{
    public class NodeContext
    {
        [JsonProperty(PropertyName ="description")]
        public string description { get; private set; }

        [JsonProperty(PropertyName = "path")]
        public string path { get; private set; }

        [JsonProperty(PropertyName = "port")]
        public string port { get; private set; }

        public NodeContext() { }

        public NodeContext(NodeContextParameters parameters)
        {
            this.description = parameters.description;
            this.path = parameters.path;
            this.port = parameters.port;
        }
    }
}
