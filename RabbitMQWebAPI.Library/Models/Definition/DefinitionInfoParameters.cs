using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition
{
    public struct DefinitionInfoParameters
    {
        public string rabbit_version;
        public List<DefinitionUser.DefinitionUser> users;
        public List<Dictionary<string, string>> vhosts;
        public List<DefinitionPermission.DefinitionPermission> permissions;
        public List<DefinitionParameter.DefinitionParameter> parameters;
        public List<DefinitionPolicy.DefinitionPolicy> policies;
        public List<DefinitionQueue.DefinitionQueue> queues;
        public List<DefinitionExchange.DefinitionExchange> exchanges;
        public List<DefinitionBinding.DefinitionBinding> bindings;
    }
}
