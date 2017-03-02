using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionBinding
{
    public class DefinitionBinding: Model
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }

        [JsonProperty(PropertyName = "type")]
        public string type { get; internal set; }

        [JsonProperty(PropertyName = "durable")]
        public bool durable { get; internal set; }

        [JsonProperty(PropertyName = "auto_delete")]
        public bool auto_delete { get; internal set; }

        [JsonProperty(PropertyName = "internal")]
        public bool _internal { get; internal set; }

        [JsonProperty("arguments")]
        public Dictionary<string, string> arguments { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "source",
            "vhost",
            "destination",
            "destination_type",
            "routing_key",
            "arguments"
        };
            }

            set { Keys = value; }
        }

        public DefinitionBinding() { }

        
    }
}
