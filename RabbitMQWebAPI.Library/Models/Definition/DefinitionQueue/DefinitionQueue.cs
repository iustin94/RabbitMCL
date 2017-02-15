using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionQueue
{
    public class DefinitionQueue
    {
        public string name { get; private set; }
        public string vhost { get; private set; }
        public bool durable { get; private set; }
        public bool auto_delete { get; private set; }
        public Dictionary<string,string> arguments { get; private set; }

        public DefinitionQueue() { }
        public DefinitionQueue(DefinitionQueueParameters parameters)
        {
            this.name = parameters.name;
            this.vhost = parameters.vhost;
            this.durable = parameters.durable;
            this.auto_delete = parameters.auto_delete;
            this.arguments = arguments;
        }
    }
}
