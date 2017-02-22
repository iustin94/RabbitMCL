using System.Collections.Generic;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Connection
{
    public class ConnectionInfo
    {
        [JsonProperty(PropertyName = "connected_at")]
        public string connected_at { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public string type { get; private set; }

        [JsonProperty(PropertyName = "client_properties")]
        public Dictionary<string, string> client_properties { get; private set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; private set; }

        [JsonProperty(PropertyName = "user")]
        public string user { get; private set; }
        
        [JsonProperty(PropertyName = "name")]
        public string name { get; private set; }
        
        [JsonProperty(PropertyName = "protocol")]
        public string protocol { get; private set; }
        
        [JsonProperty(PropertyName = "node")]
        public string node { get; private set; }

        public ConnectionInfo() { }
        public ConnectionInfo(ConnectionInfoParameters parameters)
        {
            this.connected_at = parameters.connected_at;
            this.type = parameters.type;
            this.client_properties = parameters.client_properties;
            this.vhost = parameters.vhost;
            this.user = parameters.user;
            this.name = parameters.name;
            this.protocol = parameters.protocol;
            this.node = parameters.node;
        }
    }
}
