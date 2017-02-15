using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink
{
    public class NodeClusterLink
    {
        public string peer_addr { get; private set; }
        public int peer_port { get; private set; }
        public string sock_addr { get; private set; }
        public int sock_port { get; private set; }
        public NodeClusterLinkStats.NodeClusterLinkStats stats { get; private set; }
        public string name { get; private set; }

        public NodeClusterLink() { }

        public NodeClusterLink(NodeClusterLinkParameters parameters)
        {
            this.peer_addr = parameters.peer_addr;
            this.peer_port = parameters.peer_port;
            this.sock_addr = parameters.sock_addr;
            this.sock_port = parameters.sock_port;
            this.stats = parameters.stats;
            this.name = parameters.name;
        }
    }
}
