using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Vhost
{
    public struct VhostInfoParameters
    {
        public VhostInfoMessageStats.VhostInfoMessageStats message_stats;

        public int send_oct;
        public IDictionary<string, int> send_oct_details;

        public int recv_oct;
        public IDictionary<string, int> recv_oct_details;

        public int messages;
        public IDictionary<string, int> messages_details;

        public int messages_ready;
        public IDictionary<string, int> messages_ready_details;

        public int messages_unacknowledged;
        public IDictionary<string, int> messages_unacknowledged_details;

        public string name;
        public bool tracing;

    }
}
