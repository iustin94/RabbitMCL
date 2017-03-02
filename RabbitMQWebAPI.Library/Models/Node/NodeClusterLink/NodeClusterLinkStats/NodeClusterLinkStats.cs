using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats
{
    public class NodeClusterLinkStats: Model
    {
        [JsonProperty(PropertyName = "send_bytes")]
        public double send_bytes { get; internal set; }

        [JsonProperty(PropertyName = "send_bytes_details")]
        public Dictionary<string, double> send_bytes_details { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "send_bytes",
            "send_bytes_details"
        };
            }

            set { Keys = value; }
        }

        public NodeClusterLinkStats() { }

      
    }
}
