using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Definition
{
    public class Definition : Model
    {
        [JsonProperty(PropertyName = "rabbit_version")]
        public string rabbit_version { get; internal set; }

        [JsonProperty(PropertyName = "users")]
        public List<Models.Definition.DefinitionUser.DefinitionUser> users { get; internal set; }

        [JsonProperty(PropertyName = "vhosts")]
        public List<Dictionary<string, string>> vhosts { get; internal set; }

        [JsonProperty(PropertyName = "permissions")]
        public List<Models.Definition.DefinitionPermission.DefinitionPermission> permissions { get; internal set; }

        [JsonProperty(PropertyName = "parameters")]
        public List<Models.Definition.DefinitionParameter.DefinitionParameter> parameters { get; internal set; }

        [JsonProperty(PropertyName = "policies")]
        public List<Models.Definition.DefinitionPolicy.DefinitionPolicy> policies { get; internal set; }

        [JsonProperty(PropertyName = "queues")]
        public List<Models.Definition.DefinitionQueue.DefinitionQueue> queues { get; internal set; }

        [JsonProperty(PropertyName = "exchanges")]
        public List<Models.Definition.DefinitionExchange.DefinitionExchange> exchanges { get; internal set; }

        [JsonProperty(PropertyName = "bindings")]
        public List<Models.Definition.DefinitionBinding.DefinitionBinding> bindings { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "rabbit_version",
            "users",
            "vhosts",
            "permissions",
            "parameters",
            "policies",
            "queues",
            "exchanges",
            "bindings"
        };
            }

            set { Keys = value; }
        }

        public Definition() { }
        
    }
}
