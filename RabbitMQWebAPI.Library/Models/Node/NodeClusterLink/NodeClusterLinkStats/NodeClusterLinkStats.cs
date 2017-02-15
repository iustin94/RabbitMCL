using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats
{
    public class NodeClusterLinkStats
    {
        public int send_bytes { get; private set; }
        public Dictionary<string,int> send_bytes_details { get; private set; }

        public NodeClusterLinkStats() { }

        public NodeClusterLinkStats(NodeClusterLinkStatsParameters parameters)
        {
            this.send_bytes = parameters.send_bytes;
            this.send_bytes_details = parameters.send_bytes_details;
        }
    }
}
