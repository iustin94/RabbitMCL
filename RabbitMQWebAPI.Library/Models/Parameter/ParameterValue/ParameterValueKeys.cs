using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Parameter.ParameterValue
{
    public static class ParameterValueKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "src_uri",
            "src_queue",
            "dest_uri",
            "dest_queue",
            "prefetch_count",
            "reconnect_delay",
            "add_forward_headers",
            "ack-mode",
            "delete_after"
        };
    }
}
