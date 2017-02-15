using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy
{
    public class DefinitionPolicy
    {
        public string vhost { get; private set; }
        public string name { get; private set; }
        public string pattern { get; private set; }
        public string apply_to { get; private set; }
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
