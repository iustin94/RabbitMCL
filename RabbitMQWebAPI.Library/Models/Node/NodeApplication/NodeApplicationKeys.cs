using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeApplication
{
    public static class NodeApplicationKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "description",
            "version"
        };
    }
}
