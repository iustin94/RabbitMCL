using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models
{
    public class ExchangeInfo
    {
        public string name;
        public string vhost;
        public string type;
        public bool auto_delete;
        public bool durable;
        public bool internal_exchange;
        public IDictionary<string, string> arguments;

        public ExchangeInfo(string name,
            string vhost,
            string type,
            bool durable,
            bool auto_delete,
            bool internal_exchange,
            IDictionary<string, string> arguments)
        {
            this.name = name;
            this.vhost = vhost;
            this.type = type;
            this.durable = durable;
            this.auto_delete = auto_delete;
            this.arguments = arguments;
            this.internal_exchange = internal_exchange;
        }
    }
}
