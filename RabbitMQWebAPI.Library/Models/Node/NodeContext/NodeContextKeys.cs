using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeContext
{
    public static class NodeContextKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "description",
            "path",
            "port"
        };
    }
}
