using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Consumer.ChannelDetails
{
    public struct ChannelDetailsParameters
    {
        public string name;
        public string number;
        public string user;
        public string connection_name;
        public string peer_port;
        public string peer_host;
    }
}
