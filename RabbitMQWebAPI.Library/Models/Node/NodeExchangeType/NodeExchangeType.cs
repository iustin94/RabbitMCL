using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeExchangeType
{
    public class NodeExchangeType: Model
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

            set
            {
                throw new NotImplementedException();
            }
        }

        public NodeExchangeType() { }
    }
}
