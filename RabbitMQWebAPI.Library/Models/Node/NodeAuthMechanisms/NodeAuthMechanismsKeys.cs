using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms
{
    public static class NodeAuthMechanismsKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "description",
            "enabled"
        };
    }
}
