using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueue;

namespace RabbitMQWebAPI.Library.Models.Queue
{
    public class QueueInfo
    {
        [JsonProperty(PropertyName = "memory")]
        public double memory { get; internal set; }

        [JsonProperty(PropertyName = "reductions")]
        public double reductions { get; internal set; }

        [JsonProperty(PropertyName = "reductions_details")]
        public Dictionary<string, double> redutions_details { get; internal set; }

        [JsonProperty(PropertyName = "messages")]
        public double messages { get; internal set; }

        [JsonProperty(PropertyName = "messages_details")]
        public Dictionary<string, double> messages_details { get; internal set; }

        [JsonProperty(PropertyName = "messages_ready")]
        public double messages_ready { get; internal set; }

        [JsonProperty(PropertyName = "messages_ready_details")]
        public Dictionary<string, double> messages_ready_details { get; internal set; }

        [JsonProperty(PropertyName = "messages_unacknowledged")]
        public double messages_unacknowledged { get; internal set; }

        [JsonProperty(PropertyName = "messages_unacknowledged_details")]
        public Dictionary<string, double> messages_unacknowledged_details { get; internal set; }

        [JsonProperty(PropertyName = "idle_since")]
        public string idle_since { get; internal set; }

        [JsonProperty(PropertyName = "consumer_utilisation")]
        public string consumer_utilisation { get; internal set; }

        [JsonProperty(PropertyName = "policy")]
        public string policy { get; internal set; }

        [JsonProperty(PropertyName = "exclusive_consumer_tag")]
        public string exclusive_consumer_tag { get; internal set; }

        [JsonProperty(PropertyName = "consumers")]
        public double consumers { get; internal set; }

        [JsonProperty(PropertyName = "recoverable_slaves")]
        public string recoverable_slaves { get; internal set; }

        [JsonProperty(PropertyName = "state")]
        public State.StateEnum state { get; internal set; }

        [JsonProperty(PropertyName = "garbage_collection")]
        public QueueGarbageCollection.QueueGarbageCollection garbage_collection { get; internal set; }

        [JsonProperty(PropertyName = "messages_ram")]
        public double messages_ram { get; internal set; }

        [JsonProperty(PropertyName = "messages_ready_ram")]
        public double messages_ready_ram { get; internal set; }

        [JsonProperty(PropertyName = "messages_unacknowledged_ram")]
        public double messages_unacknowledged_ram { get; internal set; }

        [JsonProperty(PropertyName = "messages_persistent")]
        public double messages_persistent { get; internal set; }

        [JsonProperty(PropertyName = "message_bytes")]
        public double message_bytes { get; internal set; }

        [JsonProperty(PropertyName = "messages_bytes_ready")]
        public double message_bytes_ready { get; internal set; }

        [JsonProperty(PropertyName = "message_bytes_unacknowledged")]
        public double message_bytes_unacknowledged { get; internal set; }

        [JsonProperty(PropertyName = "message_bytes_ram")]
        public double message_bytes_ram { get; internal set; }

        [JsonProperty(PropertyName = "message_bytes_persistent")]
        public double message_bytes_persistent { get; internal set; }

        [JsonProperty(PropertyName = "head_message_timestamp")]
        public string head_message_timestamp { get; internal set; }

        [JsonProperty(PropertyName = "disk_reads")]
        public double disk_reads { get; internal set; }

        [JsonProperty(PropertyName = "disk_writes")]
        public double disk_writes { get; internal set; }

        [JsonProperty(PropertyName = "backing_queue_status")]
        public QueueBackingQueueStatus backing_queue_status { get; internal set; }

        [JsonProperty(PropertyName = "node")]
        public string node { get; internal set; }

        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string, string> arguments { get; internal set; }

        [JsonProperty(PropertyName = "exclusive")]
        public bool exclusive { get; internal set; }

        [JsonProperty(PropertyName = "auto_delete")]
        public bool auto_delete { get; internal set; }

        [JsonProperty(PropertyName = "durable")]
        public bool durable { get; internal set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }
        
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        public QueueInfo() { }

        public QueueInfo(QueueInfoParameters parameters)
        {
            this.memory = parameters.memory;
            this.reductions = parameters.reductions;
            this.redutions_details = parameters.recutions_details;
            this.messages = parameters.messages;
            this.messages_details = parameters.messages_details;
            this.messages_ready = parameters.messages_ready;
            this.messages_ready_details = parameters.messages_ready_details;
            this.messages_unacknowledged = parameters.messages_unacknowledged;
            this.messages_unacknowledged_details = parameters.messages_unacknowledged_details;
            this.idle_since = parameters.idle_since;
            this.consumer_utilisation = parameters.consumer_utilisation;
            this.policy = parameters.policy;
            this.exclusive_consumer_tag = parameters.exclusive_consumer_tag;
            this.consumers = parameters.consumers;
            this.recoverable_slaves = parameters.recoverable_slaves;
            this.state = parameters.state;
            this.garbage_collection = parameters.garbage_collection;
            this.messages_ram = parameters.messages_ram;
            this.messages_ready_ram = parameters.messages_ready_ram;
            this.messages_unacknowledged_ram = parameters.messages_unacknowledged_ram;
            this.messages_persistent = parameters.messages_persistent;
            this.message_bytes = parameters.message_bytes;
            this.message_bytes_unacknowledged = parameters.message_bytes_unacknowledged;
            this.message_bytes_ram = parameters.message_bytes_ram;
            this.message_bytes_persistent = parameters.message_bytes_persistent;
            this.head_message_timestamp = parameters.head_message_timestamp;
            this.disk_reads = parameters.disk_reads;
            this.disk_writes = parameters.disk_writes;
            this.backing_queue_status = parameters.backing_queue_status;
            this.node = parameters.node;
            this.arguments = parameters.arguments;
            this.exclusive = parameters.exclusive;
            this.auto_delete = parameters.auto_delete;
            this.durable = parameters.durable;
            this.vhost = parameters.vhost;
            this.name = parameters.name;
        }

    }
}
