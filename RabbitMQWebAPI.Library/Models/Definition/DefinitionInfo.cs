using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Definition;

namespace RabbitMQWebAPI.Library.Models
{
    public class DefinitionInfo
    {
        public string rabbit_version { get; private set; }
        public List<Definition.DefinitionUser.DefinitionUser> users { get; private set; }
        public List<Dictionary<string, string>> vhosts { get; private set; }
        public List<Definition.DefinitionPermission.DefinitionPermission> permissions { get; private set; }
        public List<Definition.DefinitionParameter.DefinitionParameter> parameters { get; private set; }
        public List<Definition.DefinitionPolicy.DefinitionPolicy> policies { get; private set; }
        public List<Definition.DefinitionQueue.DefinitionQueue> queues { get; private set; }
        public List<Definition.DefinitionExchange.DefinitionExchange> exchanges { get; private set; }
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
