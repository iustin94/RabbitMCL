using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Exchange
{
    public static class ExchangeInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "message_stats",
            "name",
            "vhost",
            "type",
            "durable",
            "auto_delete",
            "internal",
            "arguments"
        };
    }
}
