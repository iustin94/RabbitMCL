using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeApplication
{
    public class NodeApplicationSentinel : Sentinel<NodeApplication>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeApplication parameters = new NodeApplication();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.description = parametersDictionary["description"].ToString();
            parameters.version = parametersDictionary["version"].ToString();

            return parameters;
        }
    }
}
