using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Exchange
{
    public class ExchangeInfo
    {
        public ExchangeMessageStats.ExchangeMessageStats message_stats { get; private set; }
        public string name { get; private set; }
        public string vhost { get; private set; }
        public string type { get; private set; }
        public bool durable { get; private set; }
        public bool auto_delete { get; private set; }
        public bool _internal { get; private set; }
        public Dictionary<string, string> arguments { get; private set; }

        public ExchangeInfo() { }

        public ExchangeInfo(ExchangeInfoParameters parameters)
        {
            this.message_stats = parameters.message_stats;
            this.name = parameters.name;
            this.vhost = parameters.vhost;
            this.type = parameters.type;
            this.durable = parameters.durable;
            this.auto_delete = parameters.auto_delete;
            this._internal = parameters._internal;
            this.arguments = parameters.arguments;
        }
    }
}
