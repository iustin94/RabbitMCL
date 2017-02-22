using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Queue
{
    public class QueueInfo
    {
        [JsonProperty(PropertyName = "memory")]
        public int memory { get; internal set; }
        //public int reductions { get; private set; }
        //public Dictionary<string, int> redutions_details { get; private set; }
        //public int messages { get; private set; }
        //public Dictionary<string, int> messages_details { get; private set; }
        //public int messages_ready { get; private set; }
        //public Dictionary<string, int> messages_ready_details { get; private set; }
        [JsonProperty(PropertyName = "messages_unacknowledged")]
        public int messages_unacknowledged { get; internal set; }
        //public Dictionary<string, int> messages_unacknowledged_details { get; private set; }
        //public string idle_since { get; private set; }
        //public string consumer_utilisation { get; private set; }
        //public string policy { get; private set; }
        //public string exclusive_consumer_tag { get; private set; }
        //public int consumers { get; private set; }
        //public string recoverable_slaves { get; private set; }
        //public State.StateEnum state { get; private set; }
        //public QueueGarbageCollection.QueueGarbageCollection garbage_collection { get; private set; }
        //public int messages_ram { get; private set; }
        //public int messages_ready_ram { get; private set; }
        //public int messages_unacknowledged_ram { get; private set; }
        //public int messages_persistent { get; private set; }
        //public int message_bytes { get; private set; }
        //public int message_bytes_ready { get; private set; }
        //public int message_bytes_unacknowledged { get; private set; }
        //public int message_bytes_ram { get; private set; }
        //public int message_bytes_persistent { get; private set; }
        //public string head_message_timestamp { get; private set; }
        //public int disk_reads { get; private set; }
        //public int disk_writes { get; private set; }
        //public QueueBackingQueueStatus.QueueBackingQueueStatus backing_queue_status { get; private set; }
        //public string node { get; private set; }
        //public Dictionary<string, string> arguments { get; private set; }
        //public bool exclusive { get; private set; }
        //public bool auto_delete { get; private set; }
        //public bool durable { get; private set; }
        //public string vhost { get; private set; }
        //public string name { get; private set; }

        public QueueInfo() { }

        //public QueueInfo(QueueInfoParameters parameters)
        //{
        //    this.memory = parameters.memory;
        //    this.reductions = parameters.reductions;
        //    this.redutions_details = parameters.recutions_details;
        //    this.messages = parameters.messages;
        //    this.messages_details = parameters.messages_details;
        //    this.messages_ready = parameters.messages_ready;
        //    this.messages_ready_details = parameters.messages_ready_details;
        //    this.messages_unacknowledged = parameters.messages_unacknowledged;
        //    this.messages_unacknowledged_details = parameters.messages_unacknowledged_details;
        //    this.idle_since = parameters.idle_since;
        //    this.consumer_utilisation = parameters.consumer_utilisation;
        //    this.policy = parameters.policy;
        //    this.exclusive_consumer_tag = parameters.exclusive_consumer_tag;
        //    this.consumers = parameters.consumers;
        //    this.recoverable_slaves = parameters.recoverable_slaves;
        //    this.state = parameters.state;
        //    this.garbage_collection = parameters.garbage_collection;
        //    this.messages_ram = parameters.messages_ram;
        //    this.messages_ready_ram = parameters.messages_ready_ram;
        //    this.messages_unacknowledged_ram = parameters.messages_unacknowledged_ram;
        //    this.messages_persistent = parameters.messages_persistent;
        //    this.message_bytes = parameters.message_bytes;
        //    this.message_bytes_unacknowledged = parameters.message_bytes_unacknowledged;
        //    this.message_bytes_ram = parameters.message_bytes_ram;
        //    this.message_bytes_persistent = parameters.message_bytes_persistent;
        //    this.head_message_timestamp = parameters.head_message_timestamp;
        //    this.disk_reads = parameters.disk_reads;
        //    this.disk_writes = parameters.disk_writes;
        //    this.backing_queue_status = parameters.backing_queue_status;
        //    this.node = parameters.node;
        //    this.arguments = parameters.arguments;
        //    this.exclusive = parameters.exclusive;
        //    this.auto_delete = parameters.auto_delete;
        //    this.durable = parameters.durable;
        //    this.vhost = parameters.vhost;
        //    this.name = parameters.name;
        //} 
     
    }
}
