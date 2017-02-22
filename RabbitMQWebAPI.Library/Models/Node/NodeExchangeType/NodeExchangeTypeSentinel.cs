using System;
using System.Collections.Generic;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeExchangeType
{
    public class NodeExchangeTypeSentinel : Sentinel<NodeExchangeType, NodeExchangeTypeParameters>
    {
        public override NodeExchangeTypeParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeExchangeTypeParameters parameters = new NodeExchangeTypeParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.enabled = Boolean.Parse(parametersDictionary["enabled"].ToString());
            parameters.description = parametersDictionary["description"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in NodeExchangeTypeKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
