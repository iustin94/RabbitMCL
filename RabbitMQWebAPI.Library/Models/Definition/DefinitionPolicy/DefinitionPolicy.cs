using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy
{
    public class DefinitionPolicy:Model
    {

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "pattern")]
        public string pattern { get; internal set; }

        [JsonProperty(PropertyName = "apply_to")]
        public string apply_to { get; internal set; }

        [JsonProperty(PropertyName = "definition")]
        public DefinitionPolicyDefinition.DefinitionPolicyDefinition definition { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "vhost",
            "name",
            "pattern",
            "apply-to",
            "definition",
            "priority"
        };
            }

            set { Keys = value; }
        }

        public int priority;

        public DefinitionPolicy() { }

    
    }
}
