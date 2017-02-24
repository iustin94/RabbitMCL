using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Consumer;
using RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public class Consumer:Model
    {
        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string, string> arguments { get; internal set; }

        [JsonProperty(PropertyName = "prefetch_count")]
        public int prefetch_count { get; internal set; }

        [JsonProperty(PropertyName = "ack_required")]
        public bool ack_required { get; internal set; }

        [JsonProperty(PropertyName = "exclusive")]
        public bool exclusive { get; internal set; }

        [JsonProperty(PropertyName = "consumer_tag")]
        public string consumer_tag { get; internal set; }

        [JsonProperty(PropertyName = "queue")]
        public Dictionary<string, string> queue { get; internal set; }

        [JsonProperty(PropertyName = "channel_details")]
        public ConsumerChannelDetails.ConsumerChannelDetails channel_details { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "arguments",
            "prefetch_count",
            "ack_required",
            "exclusive",
            "consumer_tag",
            "queue",
            "channel_details"
        };
            }

            set { Keys = value; }
        }

        public Consumer() { }
       
    }
}
