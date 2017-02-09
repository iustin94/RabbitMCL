using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public struct ConnectionDetailsParameters
    {
        public string name;
        public string peer_port;
        public string peer_host;
    }
}
