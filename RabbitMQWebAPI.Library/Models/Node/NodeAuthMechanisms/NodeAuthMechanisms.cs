using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms
{
    public class NodeAuthMechanisms:Model
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; internal set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool enabled { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "name",
            "description",
            "enabled"
        };
            }

            set { Keys = value; }
        }

        public NodeAuthMechanisms() { }

     
    }
}
