using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionBinding
{
    public class DefinitionBinding
    {
        public string name { get; private set; }
        public string vhost { get; private set; }
        public string type { get; private set; }
        public bool durable { get; private set; }
        public bool auto_delate { get; private set; }
        public bool _internal { get; private set; }
        public Dictionary<string, string> arguments { get; private set; }

        public DefinitionBinding() { }

        public DefinitionBinding(DefinitionBindingParameters parameters)
        {
            this.name = parameters.name;
            this.vhost = parameters.vhost;
            this.type = parameters.type;
            this.durable = parameters.durable;
            this.auto_delate = parameters.auto_delate;
            this._internal = parameters._internal;
            this.arguments = parameters.arguments;
        }
    }
}
