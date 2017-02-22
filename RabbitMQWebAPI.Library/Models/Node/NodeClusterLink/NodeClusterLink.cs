using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink
{
    public class NodeClusterLink
    {
        [JsonProperty(PropertyName = "peer_addr")]
        public string peer_addr { get; private set; }

        [JsonProperty(PropertyName = "peer_port")]
        public int peer_port { get; private set; }

        [JsonProperty(PropertyName = "sock_addr")]
        public string sock_addr { get; private set; }

        [JsonProperty(PropertyName = "sock_port")]
        public int sock_port { get; private set; }
        
        [JsonProperty(PropertyName = "stats")]
        public NodeClusterLinkStats.NodeClusterLinkStats stats { get; private set; }

        [JsonProperty(PropertyName = "name")]
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
