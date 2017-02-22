using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionQueue
{
    public class DefinitionQueue
    {
        [JsonProperty(PropertyName = "name" )]
        public string name { get; private set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; private set; }

        [JsonProperty(PropertyName = "durable")]
        public bool durable { get; private set; }

        [JsonProperty(PropertyName = "auto_delete")]
        public bool auto_delete { get; private set; }

        [JsonProperty(PropertyName = "arguments")]
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
