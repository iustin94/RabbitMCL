using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition
{
    public static class PolicyDefinitionKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "ha-mode",
            "ha-sync-mode",
            "ha-sync-batch-size"
        };
    }
}
