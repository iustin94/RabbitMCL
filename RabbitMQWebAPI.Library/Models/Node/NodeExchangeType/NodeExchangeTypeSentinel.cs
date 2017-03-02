using System;
using System.Collections.Generic;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeExchangeType
{
    public class NodeExchangeTypeSentinel : Sentinel<NodeExchangeType>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeExchangeType parameters = new NodeExchangeType();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.enabled = Boolean.Parse(parametersDictionary["enabled"].ToString());
            parameters.description = parametersDictionary["description"].ToString();

            return parameters;
        }
    }
}
