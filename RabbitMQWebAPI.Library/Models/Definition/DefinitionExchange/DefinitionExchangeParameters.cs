using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionExchange
{
    public struct DefinitionExchangeParameters
    {
        public string name;
        public string vhost;
        public string type;
        public bool durable;
        public bool auto_delete;
        public bool _internal;
        public Dictionary<string, string> arguments;
    }
}
