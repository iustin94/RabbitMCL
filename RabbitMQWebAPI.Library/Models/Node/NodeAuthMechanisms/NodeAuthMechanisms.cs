using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms
{
    public class NodeAuthMechanisms
    {
        public string name { get; private set; }
        public string descrition { get; private set; }
        public bool enabled { get; private set; }
        
        public NodeAuthMechanisms() { }

        public NodeAuthMechanisms(NodeAuthMechanismsParameters parameters)
        {
            this.name = parameters.name;
            this.descrition = parameters.description;
            this.enabled = parameters.enabled;
        }
    }
}
