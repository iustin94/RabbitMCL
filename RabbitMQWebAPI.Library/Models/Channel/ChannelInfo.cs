using System.Collections.Generic;
using Newtonsoft.Json;

//I call this the franken class

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public class ChannelInfo
    {
        [JsonProperty(PropertyName = "vhost")]   
        public string vhost { private set; get; }

        [JsonProperty(PropertyName = "user")]
        public string user { private set; get; }

        [JsonProperty(PropertyName = "number")]
        public int number { private set; get; }

        [JsonProperty(PropertyName = "name")]
        public string name { private set; get; }
        
        [JsonProperty(PropertyName = "node")]
        public string node { private set; get; }
        
        [JsonProperty(PropertyName = "garbage_collection")]
        public ChannelGarbageCollection.ChannelGarbageCollection garbage_collection { private set; get; }

        [JsonProperty(PropertyName = "reductions")]
        public int reductions { private set; get; }

        [JsonProperty(PropertyName = "state")]
        public State.StateEnum state { private set; get; }

        [JsonProperty(PropertyName = "prefetch_count")]
        public int prefetch_count { private set; get; }

        [JsonProperty(PropertyName = "acks_uncommitted")]
        public int acks_uncommitted { private set; get; }

        [JsonProperty(PropertyName = "messages_uncommitted")]
        public int messages_uncommitted { private set; get; }
        
        [JsonProperty(PropertyName = "messages_unconfirmed")]
        public int messages_unconfirmed { private set; get; }

        [JsonProperty(PropertyName = "messages_unacknowledge")]
        public int messages_unacknowledged { private set; get; }

        [JsonProperty(PropertyName = "consumer_count")]
        public int consumer_count { private set; get; }

        [JsonProperty(PropertyName = "confirms")]
        public bool confirms { private set; get; }

        [JsonProperty(PropertyName = "transactional")]
        public bool transactional { private set; get; }

        [JsonProperty(PropertyName = "idle_since")]
        public string idle_since { private set; get; }

        [JsonProperty(PropertyName = "reduction_details")]
        public IDictionary<string, int> reduction_details { private set; get; }

        [JsonProperty(PropertyName = "channel_message_stats")]
        public ChannelMessageStats.ChannelMessageStats channel_message_stats { private set; get; }

        [JsonProperty(PropertyName = "channel_connection_details")]
        public ChannelConnectionDetails.ChannelConnectionDetails channel_connection_details { private set; get; }

        [JsonProperty(PropertyName = "global_prefetch_count")]
        public int global_prefetch_count { private set; get; }

        public ChannelInfo() { }
        public ChannelInfo(ChannelInfoParameters parameters)
        {
            this.vhost = parameters.vhost;
            this.user = parameters.user;
            this.number = parameters.number;
            this.name = parameters.name;
            this.node = parameters.node;
            this.garbage_collection = parameters.garbage_collection;
            this.reductions = parameters.reductions;
            this.state = parameters.state;
            this.prefetch_count = parameters.prefetch_count;
            this.acks_uncommitted = parameters.acks_uncommitted;
            this.messages_uncommitted = parameters.messages_uncommitted;
            this.messages_unconfirmed = parameters.messages_unconfirmed;
            this.messages_unacknowledged = parameters.messages_unacknowledged;
            this.consumer_count = parameters.consumer_count;
            this.confirms = parameters.confirms;
            this.transactional = parameters.transactional;
            this.idle_since = parameters.idle_since;
            this.reduction_details = parameters.reduction_details;
            this.channel_message_stats = parameters.ChannelMessageStats;
            this.channel_connection_details = parameters.ChannelConnectionDetails;
            this.global_prefetch_count = parameters.global_prefetch_count;
        }
    }
}
