using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeContext
{
    public class NodeContextSentinel: Sentinel<NodeContext>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary)
        {
            NodeContext parameters = new NodeContext();
            parameters.port = parametersDictionary["port"].ToString();
            parameters.path = parametersDictionary["path"].ToString();
            parameters.description = parametersDictionary["description"].ToString();

            return parameters;
        }
    }
}
