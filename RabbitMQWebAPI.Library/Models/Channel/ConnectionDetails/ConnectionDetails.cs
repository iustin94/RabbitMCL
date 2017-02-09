using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.ConnectionDetails
{
    public class ConnectionDetails
    {
        public string name;
        public string peer_port;
        public string peer_host;

        public ConnectionDetails(ConnectionDetailsParameters parameters)
        {
            this.name = parameters.name;
            peer_port = parameters.peer_port;
            peer_host = parameters.peer_host;
        }
    }
}
