using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink
{
    public static class NodeClusterLinkKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "peer_addr",
            "peer_port",
            "sock_addr",
            "sock_port",
            "stats",
            "name"

        };
     }
}
