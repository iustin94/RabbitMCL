using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats
{
    public struct NodeClusterLinkStatsParameters
    {
        public int send_bytes;
        public Dictionary<string, int> send_bytes_details;
    }
}
