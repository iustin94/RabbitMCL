using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueueStatus
{
    public static class QueueBackingQueueStatusKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "mode",
            "q1",
            "q2",
            "delta",
            "q3",
            "q4",
            "len",
            "target_ram_count",
            "next_seq_id",
            "avg_ingress_rate",
            "avg_egress_rate",
            "avg_ack_ingress_rate",
            "avg_ack_egress_rate"
        };
    }
}
