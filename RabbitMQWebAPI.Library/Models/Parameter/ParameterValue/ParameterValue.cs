using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Parameter.ParameterValue
{
    public class ParameterValue: Model
    {
        public string src_uri { get; internal set; }
        public string src_queue { get; internal set; }
        public string dest_uri { get; internal set; }
        public string dest_queue { get; internal set; }
        public double prefetch_count { get; internal set; }
        public double reconnect_delay { get; internal set; }
        public bool add_forward_headers { get; internal set; }
        public string ack_mode { get; internal set; }
        public string delete_after { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "src-uri",
            "src-queue",
            "dest-uri",
            "dest-queue",
            "prefetch-count",
            "reconnect-delay",
            "add-forward-headers",
            "ack-mode",
            "delete-after"
        };
            }

            set { Keys = value; }
        }

        public ParameterValue() { }
    }
}
