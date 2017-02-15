using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy
{
    public static class DefinitionPolicyKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "vhost",
            "name",
            "pattern",
            "apply-to",
            "definition",
            "priority"
        };
    }
}
