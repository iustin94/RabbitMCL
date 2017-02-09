using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.Connection
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
