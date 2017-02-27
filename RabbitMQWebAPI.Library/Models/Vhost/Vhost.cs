using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Vhost
{
    public class Vhost: Model
    {
        public VhostInfoMessageStats.VhostInfoMessageStats message_stats { get; internal set; } 

        public double send_oct { get; internal set; }
        public IDictionary<string, double> send_oct_details { get; internal set; }

        public double recv_oct { get; internal set; }
        public IDictionary<string, double> recv_oct_details { get; internal set; }

        public double messages { get; internal set; }
        public IDictionary<string, double> messages_details { get; internal set; }
    
        public double messages_ready { get; internal set; }
        public IDictionary<string, double> messages_ready_details { get; internal set; }

        public double messages_unacknowledged { get; internal set; }
        public IDictionary<string, double> messages_unacknowledged_details { get; internal set; }

        public string name { get; internal set; }
        public bool tracing { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            //"message_stats",
            "send_oct",
            "send_oct_details",
            "recv_oct",
            "recv_oct_details",
            "messages",
            "messages_details",
            "messages_ready",
            "messages_ready_details",
            "messages_unacknowledged",
            "messages_unacknowledged_details",
            "name",
            "tracing"
        };
            }

            set { Keys = value; }
        }

        public Vhost() { }
    }
}
