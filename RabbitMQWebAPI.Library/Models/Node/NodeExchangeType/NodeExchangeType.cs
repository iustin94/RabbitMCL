using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Node.NodeExchangeType
{
    public class NodeExchangeType
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; private set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; private set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool enabled { get; private set; }

        public NodeExchangeType() { }

        public NodeExchangeType(NodeExchangeTypeParameters parameters)
        {
            this.name = parameters.name;
            this.description = parameters.description;
            this.enabled = parameters.enabled;
        }
    }
}
