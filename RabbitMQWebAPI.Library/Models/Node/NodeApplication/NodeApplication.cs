using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Node.NodeApplication;

namespace RabbitMQWebAPI.Library.Models.Node.NodeApplication
{
    public class NodeApplication: Model
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; internal set; }

        [JsonProperty(PropertyName = "version")]
        public string version { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "name",
            "description",
            "version"
        };
            }

            set { Keys = value; }
        }

        public NodeApplication() { }

      
    }
}
