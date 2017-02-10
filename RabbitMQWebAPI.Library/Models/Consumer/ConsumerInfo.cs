using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Consumer;
using RabbitMQWebAPI.Library.Models.Consumer.ChannelDetails;

namespace RabbitMQWebAPI.Library.Models
{
    public class ConsumerInfo
    {
        public Dictionary<string, string> arguments { get; private set; }
        public int prefetch_count { get; private set; }
        public bool ack_required { get; private set; }
        public bool exclusive { get; private set; }
        public string consumer_tag { get; private set; }
        public Dictionary<string, string> queue { get; private set; }
        public ChannelDetailsInfo channel_details { get; private set; }

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
