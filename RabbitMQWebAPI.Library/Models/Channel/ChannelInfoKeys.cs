using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public static class ChannelInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "vhost",
            "user",
            "number",
            "name",
            "node",
            "garbage_collection",
            "reductions",
            "state",
            "global_prefetch_count",
            "prefetch_count",
            "acks_uncommitted",
            "messages_uncommitted",
            "messages_unconfirmed",
            "messages_unacknowledged",
            "consumer_count",
            "confirm",
            "transactional",
            "idle_since",
            "reductions_details",
            "message_stats",
            "connection_details"
        };
    }
}
