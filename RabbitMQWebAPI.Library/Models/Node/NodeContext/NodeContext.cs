using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeContext
{
    public class NodeContext: Model
    {
        [JsonProperty(PropertyName ="description")]
        public string description { get; internal set; }

        [JsonProperty(PropertyName = "path")]
        public string path { get; internal set; }

        [JsonProperty(PropertyName = "port")]
        public string port { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "description",
            "path",
            "port"
        };
            }

            set { Keys = value; }
        }

        public NodeContext() { }
    }
}
