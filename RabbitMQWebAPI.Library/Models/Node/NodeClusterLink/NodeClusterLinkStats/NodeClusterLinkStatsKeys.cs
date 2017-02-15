using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats
{
    public static class NodeClusterLinkStatsKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "send_bytes",
            "send_bytes_details"
        };
    }
}
