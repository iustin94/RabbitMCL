using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Vhost
{
    public class VhostInfo
    {
        public VhostInfoMessageStats.VhostInfoMessageStats message_stats { get; private set; } 

        public int send_oct { get; private set; }
        public IDictionary<string, int> send_oct_details { get; private set; }

        public int recv_oct { get; private set; }
        public IDictionary<string, int> recv_oct_details { get; private set; }

        public int messages { get; private set; }
        public IDictionary<string, int> messages_details { get; private set; }
    
        public int messages_ready { get; private set; }
        public IDictionary<string, int> messages_ready_details { get; private set; }

        public int messages_unacknowledged { get; private set; }
        public IDictionary<string, int> messages_unacknowledged_details { get; private set; }

        public string name { get; private set; }
        public bool tracing { get; private set; }

        public VhostInfo() { }

        public VhostInfo(VhostInfoParameters parameters)
        {
            this.message_stats = parameters.message_stats;
            this.send_oct = parameters.send_oct;
            this.send_oct_details = parameters.send_oct_details;
            this.recv_oct = parameters.recv_oct;
            this.recv_oct_details = parameters.recv_oct_details;
            this.messages = parameters.messages;
            this.messages_details = parameters.messages_details;
            this.messages_ready = parameters.messages_ready;
            this.messages_ready_details = parameters.messages_ready_details;
            this.messages_unacknowledged = parameters.messages_unacknowledged;
            this.messages_unacknowledged_details = parameters.messages_unacknowledged_details;
            this.name = parameters.name;
            this.tracing = parameters.tracing;

        }
    }
}
