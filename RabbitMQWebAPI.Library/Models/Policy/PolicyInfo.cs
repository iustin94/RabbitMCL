using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Policy
{
    public class PolicyInfo
    {
        public string vhost { get; private set; }
        public string name { get; private set; }
        public string apply_to { get; private set; }
        public PolicyDefinition.PolicyDefinition definition { get; private set; }
        public int priority { get; private set; }

        public PolicyInfo() { }

        public PolicyInfo(PolicyInfoParameters parameters)
        {
            this.vhost = parameters.vhost;
            this.name = parameters.name;
            this.apply_to = parameters.apply_to;
            this.definition = parameters.definition;
            this.priority = parameters.priority;
        }
    }
}
