using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Channel.Connection;

namespace RabbitMQWebAPI.Library.Models
{
    public class ConnectionInfo
    {
        public string connected_at { get; private set; }
        public string type { get; private set; }
        public Dictionary<string, string> client_properties { get; private set; }
        public string vhost { get; private set; }
        public string user { get; private set; }
        public string name { get; private set; }
        public string protocol { get; private set; }
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
