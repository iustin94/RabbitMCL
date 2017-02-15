using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Vhost
{
    public static class VhostInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "message_stats",
            "send_oct",
            "send_oct_details",
            "recv_oct",
            "recv_oct_details",
            "messages",
            "messages_details",
            "messages_ready",
            "messages_ready_details",
            "messages_unacknowledged",
            "messages_unacknowledged_details",
            "name",
            "tracing"
        };
    }
}
