using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms
{
    public class NodeAuthMechanismsSentinel : Sentinel<NodeAuthMechanisms, NodeAuthMechanismsParameters>
    {
        public override NodeAuthMechanismsParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeAuthMechanismsParameters parameters = new NodeAuthMechanismsParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.description = parametersDictionary["description"].ToString();
            parameters.enabled = Boolean.Parse(parametersDictionary["enabled"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in NodeAuthMechanismsKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
