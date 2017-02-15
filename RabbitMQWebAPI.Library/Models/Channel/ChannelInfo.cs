using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Channel;
using RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails;
using RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection;
using RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats;


//I call this the franken class

namespace RabbitMQWebAPI.Library.Models
{
    public class ChannelInfo
    {
       
        public string vhost { private set; get; }
        public string user { private set; get; }
        public int number { private set; get; }
        public string name { private set; get; }
        public string node { private set; get; }
        public ChannelGarbageCollection garbade_collection { private set; get; }
        public int reductions { private set; get; }
        public State.StateEnum State { private set; get; }
        public int prefetch_count { private set; get; }
        public int acks_uncommitted { private set; get; }
        public int messages_uncommitted { private set; get; }
        public int messages_unconfirmed { private set; get; }
        public int messages_unacknowledge { private set; get; }
        public int consumer_count { private set; get; }
        public bool confirms { private set; get; }
        public bool transactional { private set; get; }
        public string idle_since { private set; get; }
        public IDictionary<string, int> reduction_details { private set; get; }
        public ChannelMessageStats channel_message_stats { private set; get; }
        public ChannelConnectionDetails channel_connection_details { private set; get; }
        public int global_prefetch_count { private set; get; }

        public ChannelInfo() { }
        public ChannelInfo(ChannelInfoParameters parameters)
        {
            this.vhost = parameters.vhost;
            this.user = parameters.user;
            this.number = parameters.number;
            this.name = parameters.name;
            this.node = parameters.node;
            this.garbade_collection = parameters.garbade_collection;
            this.reductions = parameters.reductions;
            this.State = parameters.state;
            this.prefetch_count = parameters.prefetch_count;
            this.acks_uncommitted = parameters.acks_uncommitted;
            this.messages_uncommitted = parameters.messages_uncommitted;
            this.messages_unconfirmed = parameters.messages_unconfirmed;
            this.messages_unacknowledge = parameters.messages_unacknowledge;
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
