using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails
{
    public class ConsumerChannelDetailsInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; private set; }

        [JsonProperty(PropertyName = "number")]
        public string number { get; private set; }

        [JsonProperty(PropertyName = "user")]
        public string user { get; private set; }

        [JsonProperty(PropertyName = "connection")]
        public string connection_name { get; private set; }

        [JsonProperty(PropertyName = "peer_port")]
        public string peer_port { get; private set; }
        
        [JsonProperty(PropertyName = "peer_host")]
        public string peer_host { get; private set; }
        
        public ConsumerChannelDetailsInfo() { }
        public ConsumerChannelDetailsInfo(ConsumerChannelDetailsParameters parameters)
        {
            this.name = parameters.name;
            this.number = parameters.number;
            this.user = parameters.user;
            this.connection_name = parameters.connection_name;
            this.peer_port = parameters.peer_port;
            this.peer_host = parameters.peer_host;
        }
    }
}
