using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition
{
    public static class DefinitionInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
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
}
