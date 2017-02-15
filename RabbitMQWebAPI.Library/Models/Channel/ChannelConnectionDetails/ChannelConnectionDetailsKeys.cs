using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails
{
     public static class ChannelConnectionDetailsKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "peer_port",
            "peer_host"
        };
    }
}
