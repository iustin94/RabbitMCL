using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Queue
{
    public struct QueueInfoParameters
    {
        public int memory;
        public int reductions;
        public Dictionary<string, int> recutions_details;
        public int messages;
        public Dictionary<string, int> messages_details;
        public int messages_ready;
        public Dictionary<string, int> messages_ready_details;
        public int messages_unacknowledged;
        public Dictionary<string, int> messages_unacknowledged_details;
        public string idle_since;
        public string consumer_utilisation;
        public string policy;
        public string exclusive_consumer_tag;
        public int consumers;
        public string recoverable_slaves;
        public State.StateEnum state;
        public QueueGarbageCollection.QueueGarbageCollection garbage_collection;
        public int messages_ram;
        public int messages_ready_ram;
        public int messages_unacknowledged_ram;
        public int messages_persistent;
        public int message_bytes;
        public int message_bytes_unacknowledged;
        public int message_bytes_ram;
        public int message_bytes_ready;
        public int message_bytes_persistent;
        public string head_message_timestamp;
        public int disk_reads;
        public int disk_writes;
        public QueueBackingQueueStatus.QueueBackingQueueStatus backing_queue_status;
        public string node;
        public Dictionary<string, string> arguments;
        public bool exclusive;
        public bool auto_delete;
        public bool durable;
        public string vhost;
        public string name;
    }
}
