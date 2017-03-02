using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Connection
{
    public class Connection: Model
    {
        [JsonProperty(PropertyName = "connected_at")]
        public string connected_at { get; internal set; }

        [JsonProperty(PropertyName = "type")]
        public string type { get; internal set; }

        [JsonProperty(PropertyName = "client_properties")]
        public Dictionary<string, string> client_properties { get; internal set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }

        [JsonProperty(PropertyName = "user")]
        public string user { get; internal set; }
        
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }
        
        [JsonProperty(PropertyName = "protocol")]
        public string protocol { get; internal set; }
        
        [JsonProperty(PropertyName = "node")]
        public string node { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "connected_at",
            "type",
            "client_properties",
            "vhost",
            "user",
            "name",
            "protocol",
            "node"
        };
            }

            set { Keys = value; }
        }

        public Connection() { }
        
    }
}
