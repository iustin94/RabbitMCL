using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionQueue
{
    public class DefinitionQueue:Model
    {
        [JsonProperty(PropertyName = "name" )]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }

        [JsonProperty(PropertyName = "durable")]
        public bool durable { get; internal set; }

        [JsonProperty(PropertyName = "auto_delete")]
        public bool auto_delete { get; internal set; }

        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string,string> arguments { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
                {
                    "name",
                    "vhost",
                    "durable",
                    "auto_delete",
                    "arguments"
                };
            }

            set { Keys = value; }
        }

        public DefinitionQueue() { }
      
    }
}
