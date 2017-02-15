using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Exchange
{
    public struct ExchangeInfoParameters
    {
        public ExchangeMessageStats.ExchangeMessageStats message_stats;
        public string name;
        public string vhost;
        public string type;
        public bool durable;
        public bool auto_delete;
        public bool _internal;
        public Dictionary<string, string> arguments;
    }
}
