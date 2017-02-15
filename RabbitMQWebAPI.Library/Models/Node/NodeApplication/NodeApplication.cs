using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Node.NodeApplication;

namespace RabbitMQWebAPI.Library.Models.Node.NodeApplication
{
    public class NodeApplication
    {
        public string name { get; private set; }
        public string description { get; private set; }
        public string version { get; private set; }

        public NodeApplication() { }

        public NodeApplication(NodeApplicationParameters parameters)
        {
            this.name = parameters.name;
            this.description = parameters.description;
            this.version = parameters.version;
        }
    }
}
