using System.Collections.Generic;

namespace RabbitMQWebAPI.Library.Models.Connection
{
    public struct ConnectionInfoParameters
    {
        public string connected_at;
        public string type;
        public Dictionary<string, string> client_properties;
        public string vhost;
        public string user;
        public string name;
        public string protocol;
        public string node;
        
    }
}
