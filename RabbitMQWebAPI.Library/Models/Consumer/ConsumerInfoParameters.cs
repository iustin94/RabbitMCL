using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Consumer.ChannelDetails;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public struct ConsumerInfoParameters
    {
        public Dictionary<string,string> arguments;
        public int prefetch_count;
        public bool ack_required;
        public bool exclusive;
        public string consumer_tag;
        public Dictionary<string, string> queue;
        public ChannelDetailsInfo channel_details;
    }
}
