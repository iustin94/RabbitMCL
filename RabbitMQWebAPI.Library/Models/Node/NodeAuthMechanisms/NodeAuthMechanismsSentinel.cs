using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms
{
    public class NodeAuthMechanismsSentinel : Sentinel<NodeAuthMechanisms>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeAuthMechanisms parameters = new NodeAuthMechanisms();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.description = parametersDictionary["description"].ToString();
            parameters.enabled = Boolean.Parse(parametersDictionary["enabled"].ToString());

            return parameters;
        }
    }
}
