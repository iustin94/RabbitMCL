using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueue;

namespace RabbitMQWebAPI.Library.Models.Queue
{
    public class Queue: Model
    {
        [JsonProperty(PropertyName = "memory")]
        public double memory { get; internal set; }

        [JsonProperty(PropertyName = "reductions")]
        public double reductions { get; internal set; }

        [JsonProperty(PropertyName = "reductions_details")]
        public Dictionary<string, double> reductions_details { get; internal set; }

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

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
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

            set { Keys = value; }
        }

        public Queue() { }

      

    }
}
