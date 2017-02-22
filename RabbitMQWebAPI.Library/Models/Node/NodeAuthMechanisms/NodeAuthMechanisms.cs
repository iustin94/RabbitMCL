using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms
{
    public class NodeAuthMechanisms
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; private set; }

        [JsonProperty(PropertyName = "description")]
        public string descrition { get; private set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool enabled { get; private set; }
        
        public NodeAuthMechanisms() { }

        public NodeAuthMechanisms(NodeAuthMechanismsParameters parameters)
        {
            this.name = parameters.name;
            this.descrition = parameters.description;
            this.enabled = parameters.enabled;
        }
    }
}
