using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Consumer.ChannelDetails
{
    public class ChannelDetailsInfo
    {
        public string name { get; private set; }
        public string number { get; private set; }
        public string user { get; private set; }
        public string connection_name { get; private set; }
        public string peer_port { get; private set; }
        public string peer_host { get; private set; }

        public ChannelDetailsInfo(ChannelDetailsParameters parameters)
        {
            this.name = parameters.name;
            this.number = parameters.number;
            this.user = parameters.user;
            this.connection_name = parameters.connection_name;
            this.peer_port = parameters.peer_port;
            this.peer_host = parameters.peer_host;
        }
    }
}
