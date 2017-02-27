using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink
{
    public class NodeClusterLink: Model
    {
        [JsonProperty(PropertyName = "peer_addr")]
        public string peer_addr { get; internal set; }

        [JsonProperty(PropertyName = "peer_port")]
        public double peer_port { get; internal set; }

        [JsonProperty(PropertyName = "sock_addr")]
        public string sock_addr { get; internal set; }

        [JsonProperty(PropertyName = "sock_port")]
        public double sock_port { get; internal set; }
        
        [JsonProperty(PropertyName = "stats")]
        public NodeClusterLinkStats.NodeClusterLinkStats stats { get; internal set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "peer_addr",
            "peer_port",
            "sock_addr",
            "sock_port",
            "stats",
            "name"

        };
            }

            set { Keys = value; }
        }

        public NodeClusterLink() { }

        
    }
}
