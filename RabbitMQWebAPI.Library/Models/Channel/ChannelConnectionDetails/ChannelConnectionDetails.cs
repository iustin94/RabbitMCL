using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails
{
    public class ChannelConnectionDetails: Model
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "peer_port")]
        public string peer_port { get; internal set; }
        
        [JsonProperty(PropertyName = "peer_host")]
        public string peer_host { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "name",
            "peer_port",
            "peer_host"
        };
            }

            set { Keys = value; }
        }

        public ChannelConnectionDetails() { }
    }
}
