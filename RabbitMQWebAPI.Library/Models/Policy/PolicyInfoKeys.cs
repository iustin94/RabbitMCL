using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Policy
{
    public static class PolicyInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "vhost",
            "name",
            "patterm",
            "apply-to",
            "definition",
            "priority"
        };
    }
}
