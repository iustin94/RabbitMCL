using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails
{
    public class ChannelConnectionDetails
    {
        [JsonProperty(PropertyName = "name")]
        public string name;

        [JsonProperty(PropertyName = "peer_port")]
        public string peer_port;
        
        [JsonProperty(PropertyName = "peer_host")]
        public string peer_host;

        public ChannelConnectionDetails() { }
        public ChannelConnectionDetails(ChannelConnectionDetailsParameters parameters)
        {
            this.name = parameters.name;
            peer_port = parameters.peer_port;
            peer_host = parameters.peer_host;
        }
    }
}
