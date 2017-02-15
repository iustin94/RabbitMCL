using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails
{
    public static class ConsumerChannelDetailsKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "number",
            "user",
            "connection_name",
            "peer_port",
            "peer_host"
        };
    }
}
