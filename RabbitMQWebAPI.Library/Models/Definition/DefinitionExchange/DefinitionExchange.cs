using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionExchange
{
    public class DefinitionExchange
    {
        public string name { get; private set; }
        public string vhost { get; private set; }
        public string type { get; private set; }
        public bool durable { get; private set; }
        public bool auto_delete { get; private set; }
        public bool _internal { get; private set; }
        public Dictionary<string, string> arguments { get; private set; }

        public DefinitionExchange() { }

        public DefinitionExchange(DefinitionExchangeParameters parameters)
        {
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
