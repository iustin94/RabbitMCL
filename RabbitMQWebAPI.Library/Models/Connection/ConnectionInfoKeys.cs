using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Connection
{
    public static class ConnectionInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "connected_at",
            "type",
            "client_properties",
            "vhost",
            "user",
            "name",
            "protocol",
            "node"
        };
    }
}
