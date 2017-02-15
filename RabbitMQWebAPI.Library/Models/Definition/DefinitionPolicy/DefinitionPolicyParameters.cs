using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy
{
    public struct DefinitionPolicyParameters
    {
        public string vhost;
        public string name;
        public string pattern;
        public string apply_to;
        public DefinitionPolicyDefinition.DefinitionPolicyDefinition definition;
        public int priority;
    }
}
