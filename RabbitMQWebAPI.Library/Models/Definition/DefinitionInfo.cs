using System.Collections.Generic;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Definition
{
    public class DefinitionInfo
    {
        [JsonProperty(PropertyName = "rabbit_version")]
        public string rabbit_version { get; private set; }

        [JsonProperty(PropertyName = "users")]
        public List<Definition.DefinitionUser.DefinitionUser> users { get; private set; }

        [JsonProperty(PropertyName = "vhosts")]
        public List<Dictionary<string, string>> vhosts { get; private set; }

        [JsonProperty(PropertyName = "permissions")]
        public List<Definition.DefinitionPermission.DefinitionPermission> permissions { get; private set; }

        [JsonProperty(PropertyName = "parameters")]
        public List<Definition.DefinitionParameter.DefinitionParameter> parameters { get; private set; }

        [JsonProperty(PropertyName = "policies")]
        public List<Definition.DefinitionPolicy.DefinitionPolicy> policies { get; private set; }

        [JsonProperty(PropertyName = "queues")]
        public List<Definition.DefinitionQueue.DefinitionQueue> queues { get; private set; }

        [JsonProperty(PropertyName = "exchanges")]
        public List<Definition.DefinitionExchange.DefinitionExchange> exchanges { get; private set; }

        [JsonProperty(PropertyName = "bindings")]
        public List<Definition.DefinitionBinding.DefinitionBinding> bindings { get; private set; }

        public DefinitionInfo()
        {
        }

        public DefinitionInfo(DefinitionInfoParameters parameters)
        {
            this.rabbit_version = parameters.rabbit_version;
            this.users = parameters.users;
            this.vhosts = parameters.vhosts;
            this.permissions = parameters.permissions;
            this.parameters = parameters.parameters;
            this.policies = parameters.policies;
            this.queues = parameters.queues;
            this.exchanges = parameters.exchanges;
            this.bindings = parameters.bindings;
        }
    }
}
