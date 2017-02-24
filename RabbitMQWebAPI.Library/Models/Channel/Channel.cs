using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

//I call this the franken class

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public class Channel: Model
    {
        [JsonProperty(PropertyName = "vhost")]   
        public string vhost { internal set; get; }

        [JsonProperty(PropertyName = "user")]
        public string user { internal set; get; }

        [JsonProperty(PropertyName = "number")]
        public int number { internal set; get; }

        [JsonProperty(PropertyName = "name")]
        public string name { internal set; get; }
        
        [JsonProperty(PropertyName = "node")]
        public string node { internal set; get; }
        
        [JsonProperty(PropertyName = "garbage_collection")]
        public ChannelGarbageCollection.ChannelGarbageCollection garbage_collection { internal set; get; }

        [JsonProperty(PropertyName = "reductions")]
        public int reductions { internal set; get; }

        [JsonProperty(PropertyName = "state")]
        public State.StateEnum state { internal set; get; }

        [JsonProperty(PropertyName = "prefetch_count")]
        public int prefetch_count { internal set; get; }

        [JsonProperty(PropertyName = "acks_uncommitted")]
        public int acks_uncommitted { internal set; get; }

        [JsonProperty(PropertyName = "messages_uncommitted")]
        public int messages_uncommitted { internal set; get; }
        
        [JsonProperty(PropertyName = "messages_unconfirmed")]
        public int messages_unconfirmed { internal set; get; }

        [JsonProperty(PropertyName = "messages_unacknowledge")]
        public int messages_unacknowledged { internal set; get; }

        [JsonProperty(PropertyName = "consumer_count")]
        public int consumer_count { internal set; get; }

        [JsonProperty(PropertyName = "confirms")]
        public bool confirms { internal set; get; }

        [JsonProperty(PropertyName = "transactional")]
        public bool transactional { internal set; get; }

        [JsonProperty(PropertyName = "idle_since")]
        public string idle_since { internal set; get; }

        [JsonProperty(PropertyName = "reduction_details")]
        public IDictionary<string, int> reduction_details { internal set; get; }

        [JsonProperty(PropertyName = "channel_message_stats")]
        public ChannelMessageStats.ChannelMessageStats channel_message_stats { internal set; get; }

        [JsonProperty(PropertyName = "channel_connection_details")]
        public ChannelConnectionDetails.ChannelConnectionDetails channel_connection_details { internal set; get; }

        [JsonProperty(PropertyName = "global_prefetch_count")]
        public int global_prefetch_count { internal set; get; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
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

            set { Keys = value; }
        }

        public Channel() { }
       
    }
}
