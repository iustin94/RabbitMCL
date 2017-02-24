using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission
{
    public class DefinitionPermission: Model
    {

        [JsonProperty(PropertyName = "user")]
        public string user { get; internal set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }

        [JsonProperty(PropertyName = "configure")]
        public string configure { get; internal set; }

        [JsonProperty(PropertyName = "write")]
        public string write { get; internal set; }

        [JsonProperty(PropertyName = "read")]
        public string read { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "user",
            "vhost",
            "configure",
            "write",
            "read"
        };
            }

            set { Keys = value; }
        }

        public DefinitionPermission() { }
        


    }
}
