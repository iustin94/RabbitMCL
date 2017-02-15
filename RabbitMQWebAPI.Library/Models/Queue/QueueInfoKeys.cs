using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Queue
{
    public static class QueueInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "memory",
            "reductions",
            "reductions_details",
            "messages",
            "messages_details",
            "messages_ready",
            "messages_ready_details",
            "messages_unacknowledged",
            "messages_unacknowledged_details",
            "idle_since",
            "consumer_utilisation",
            "policy",
            "exclusive_consumer_tag",
            "consumers",
            "recoverable_slaves",
            "state",
            "garbage_collection",
            "messages_ram",
            "messages_ready_ram",
            "messages_unacknowledged_ram",
            "messages_persistent",
            "message_bytes",
            "message_bytes_ready",
            "message_bytes_unacknowledged",
            "message_bytes_ram",
            "message_bytes_persistent",
            "head_message_timestamp",
            "disk_reads",
            "disk_writes",
            "backing_queue_status",
            "node",
            "arguments",
            "exclusive",
            "auto_delete",
            "durable",
            "vhost",
            "name"
        };
    }
}
