using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionQueue
{
    public struct DefinitionQueueParameters
    {
        public string name;
        public string vhost;
        public bool durable;
        public bool auto_delete;
        public Dictionary<string, string> arguments;
    }
}
