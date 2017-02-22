using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Consumer;
using RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public class ConsumerInfo
    {
        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string, string> arguments { get; private set; }

        [JsonProperty(PropertyName = "prefetch_count")]
        public int prefetch_count { get; private set; }

        [JsonProperty(PropertyName = "ack_required")]
        public bool ack_required { get; private set; }

        [JsonProperty(PropertyName = "exclusive")]
        public bool exclusive { get; private set; }

        [JsonProperty(PropertyName = "consumer_tag")]
        public string consumer_tag { get; private set; }

        [JsonProperty(PropertyName = "queue")]
        public Dictionary<string, string> queue { get; private set; }

        [JsonProperty(PropertyName = "channel_details")]
        public ConsumerChannelDetailsInfo channel_details { get; private set; }

        public ConsumerInfo() { }
        public ConsumerInfo(ConsumerInfoParameters parameters)
        {
            this.arguments = parameters.arguments;
            this.prefetch_count = parameters.prefetch_count;
            this.ack_required = parameters.ack_required;
            this.exclusive = parameters.exclusive;
            this.consumer_tag = parameters.consumer_tag;
            this.queue = parameters.queue;
            this.channel_details = parameters.channel_details;
        }

    }
}
