using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeContext
{
    public class NodeContext
    {
        public string description { get; private set; }
        public string path { get; private set; }
        public string port { get; private set; }
        public NodeContext() { }

        public NodeContext(NodeContextParameters parameters)
        {
            this.description = parameters.description;
            this.path = parameters.path;
            this.port = parameters.port;
        }
    }
}
