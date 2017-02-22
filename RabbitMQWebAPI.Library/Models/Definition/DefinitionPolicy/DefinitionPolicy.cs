using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy
{
    public class DefinitionPolicy
    {

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; private set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; private set; }

        [JsonProperty(PropertyName = "pattern")]
        public string pattern { get; private set; }

        [JsonProperty(PropertyName = "apply_to")]
        public string apply_to { get; private set; }

        [JsonProperty(PropertyName = "definition")]
        public DefinitionPolicyDefinition.DefinitionPolicyDefinition definition { get; private set; }

        public int priority;

        public DefinitionPolicy() { }

        public DefinitionPolicy(DefinitionPolicyParameters parameters)
        {
            this.vhost = parameters.vhost;
            this.name = parameters.name;
            this.pattern = parameters.pattern;
            this.apply_to = parameters.apply_to;
            this.definition = parameters.definition;
            this.priority = parameters.priority;
        }
    }
}
