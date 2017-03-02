using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails
{
    public class ConsumerChannelDetails: Model
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "number")]
        public string number { get; internal set; }

        [JsonProperty(PropertyName = "user")]
        public string user { get; internal set; }

        [JsonProperty(PropertyName = "connection")]
        public string connection_name { get; internal set; }

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
            "number",
            "user",
            "connection_name",
            "peer_port",
            "peer_host"
        };
            }

            set { Keys = value; }
        }

        public ConsumerChannelDetails() { }
     
    }
}
