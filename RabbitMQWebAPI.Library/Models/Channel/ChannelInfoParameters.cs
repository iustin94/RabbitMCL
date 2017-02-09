using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public struct ChannelInfoParameters
    {
        public string vhost;
        public string user;
        public int number;
        public string name;
        public string node;
        public GarbageCollection.GarbageCollection garbade_collection;
        public int reductions;
        public State.StateEnum state;
        public int prefetch_count;
        public int acks_uncommitted;
        public int messages_uncommitted;
        public int messages_unconfirmed;
        public int messages_unacknowledge;
        public int consumer_count;
        public bool confirms;
        public bool transactional;
        public string idle_since;
        public IDictionary<string, int> reduction_details;
        public MessageStats.MessageStats message_stats;
        public ConnectionDetails.ConnectionDetails connection_details;
        public int global_prefetch_count;
    }
}
