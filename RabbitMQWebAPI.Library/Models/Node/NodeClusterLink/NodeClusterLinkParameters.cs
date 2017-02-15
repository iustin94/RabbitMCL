using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink
{
    public struct NodeClusterLinkParameters
    {
        public string peer_addr;
        public int peer_port;
        public string sock_addr;
        public int sock_port;
        public NodeClusterLinkStats.NodeClusterLinkStats stats;
        public string name;
    }
}
