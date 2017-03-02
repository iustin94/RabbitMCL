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
        public double number { internal set; get; }

        [JsonProperty(PropertyName = "name")]
        public string name { internal set; get; }
        
        [JsonProperty(PropertyName = "node")]
        public string node { internal set; get; }
        
        [JsonProperty(PropertyName = "garbage_collection")]
        public ChannelGarbageCollection.ChannelGarbageCollection garbage_collection { internal set; get; }

        [JsonProperty(PropertyName = "reductions")]
        public double reductions { internal set; get; }

        [JsonProperty(PropertyName = "state")]
        public State.StateEnum state { internal set; get; }

        [JsonProperty(PropertyName = "prefetch_count")]
        public double prefetch_count { internal set; get; }

        [JsonProperty(PropertyName = "acks_uncommitted")]
        public double acks_uncommitted { internal set; get; }

        [JsonProperty(PropertyName = "messages_uncommitted")]
        public double messages_uncommitted { internal set; get; }
        
        [JsonProperty(PropertyName = "messages_unconfirmed")]
        public double messages_unconfirmed { internal set; get; }

        [JsonProperty(PropertyName = "messages_unacknowledge")]
        public double messages_unacknowledged { internal set; get; }

        [JsonProperty(PropertyName = "consumer_count")]
        public double consumer_count { internal set; get; }

        [JsonProperty(PropertyName = "confirm")]
        public bool confirm { internal set; get; }

        [JsonProperty(PropertyName = "transactional")]
        public bool transactional { internal set; get; }

        [JsonProperty(PropertyName = "idle_since")]
        public string idle_since { internal set; get; }

        [JsonProperty(PropertyName = "reduction_details")]
        public IDictionary<string, double> reduction_details { internal set; get; }

        [JsonProperty(PropertyName = "message_stats")]
        public ChannelMessageStats.ChannelMessageStats message_stats { internal set; get; }

        [JsonProperty(PropertyName = "connection_details")]
        public ChannelConnectionDetails.ChannelConnectionDetails connection_details { internal set; get; }

        [JsonProperty(PropertyName = "global_prefetch_count")]
        public double global_prefetch_count { internal set; get; }

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
            //"message_stats", don't check for message stats since this key can actually miss from rabbitmq
            "connection_details"
        };
            }

            set { Keys = value; }
        }

        public Channel() { }
       
    }
}
