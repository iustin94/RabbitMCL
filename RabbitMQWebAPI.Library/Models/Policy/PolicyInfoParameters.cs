using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Policy
{
    public struct PolicyInfoParameters
    {
        public string vhost;
        public string name;
        public string pattern;
        public string apply_to;
        public PolicyDefinition.PolicyDefinition definition;
        public int priority;
    }
}
