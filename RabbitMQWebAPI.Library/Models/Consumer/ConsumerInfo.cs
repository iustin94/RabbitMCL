using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Consumer;
using RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public class ConsumerInfo
    {
        public Dictionary<string, string> arguments { get; private set; }
        public int prefetch_count { get; private set; }
        public bool ack_required { get; private set; }
        public bool exclusive { get; private set; }
        public string consumer_tag { get; private set; }
        public Dictionary<string, string> queue { get; private set; }
        public ConsumerChannelDetailsInfo ConsumerChannelDetails { get; private set; }

        public ConsumerInfo() { }
        public ConsumerInfo(ConsumerInfoParameters parameters)
        {
            this.arguments = parameters.arguments;
            this.prefetch_count = parameters.prefetch_count;
            this.ack_required = parameters.ack_required;
            this.exclusive = parameters.exclusive;
            this.consumer_tag = parameters.consumer_tag;
            this.queue = parameters.queue;
            this.ConsumerChannelDetails = parameters.ConsumerChannelDetails;
        }

    }
}
