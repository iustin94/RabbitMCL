using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models
{
    class ChannelInfo
    {
        //TODO

        public string vhost;
        public string user;
        public int number;
        public string name;
        public string node;
        public IDictionary<string, int> garbade_collection;
        public int reductions;
        public State.StateEnum state;



    }
}
