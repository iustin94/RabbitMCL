using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//I call this the franken class

namespace RabbitMQWebAPI.Library.Models
{
    public class ChannelInfo
    {
       
        public string vhost;
        public string user;
        public int number;
        public string name;
        public string node;
        public IDictionary<string, int> garbade_collection;
        public int reductions;
        public State.QueueStateEnum queueState;
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
        public MessageStats messageStats;
        public ConnectionDetails connection_details;

        public ChannelInfo(string vhost, string user, int number, string name, string node, 
            IDictionary<string, int> garbadeCollection, int reductions, State.QueueStateEnum queueState, 
            int prefetchCount, int acksUncommitted, int messagesUncommitted, int messagesUnconfirmed, 
            int messagesUnacknowledge, int consumerCount, bool confirms, bool transactional, string idleSince, 
            IDictionary<string, int> reductionDetails, MessageStats messageStats, ConnectionDetails connectionDetails)
        {

            //TODO 
            this.vhost = vhost;
            this.user = user;
            this.number = number;
            this.name = name;
            this.node = node;
            garbade_collection = garbadeCollection;
            this.reductions = reductions;
            this.queueState = queueState;
            prefetch_count = prefetchCount;
            acks_uncommitted = acksUncommitted;
            messages_uncommitted = messagesUncommitted;
            messages_unconfirmed = messagesUnconfirmed;
            messages_unacknowledge = messagesUnacknowledge;
            consumer_count = consumerCount;
            this.confirms = confirms;
            this.transactional = transactional;
            idle_since = idleSince;
            reduction_details = reductionDetails;
            this.messageStats = messageStats;
            connection_details = connectionDetails;
        }
    }

    public class ConnectionDetails
    {
        public string name;
        public string peer_port;
        public string peer_host;

        public ConnectionDetails(string name, string peerPort, string peerHost)
        {
            this.name = name;
            peer_port = peerPort;
            peer_host = peerHost;
        }
    }
}
