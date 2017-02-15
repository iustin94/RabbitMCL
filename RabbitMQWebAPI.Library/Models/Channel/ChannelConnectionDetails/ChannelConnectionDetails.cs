using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails
{
    public class ChannelConnectionDetails
    {
        public string name;
        public string peer_port;
        public string peer_host;

        public ChannelConnectionDetails() { }
        public ChannelConnectionDetails(ChannelConnectionDetailsParameters parameters)
        {
            this.name = parameters.name;
            peer_port = parameters.peer_port;
            peer_host = parameters.peer_host;
        }
    }
}
