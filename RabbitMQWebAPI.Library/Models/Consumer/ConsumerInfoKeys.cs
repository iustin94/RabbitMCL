using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public static class ConsumerInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
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
}
