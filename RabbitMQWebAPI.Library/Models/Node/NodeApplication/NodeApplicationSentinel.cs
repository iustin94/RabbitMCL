using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeApplication
{
    public class NodeApplicationSentinel : Sentinel<NodeApplication, NodeApplicationParameters>
    {
        public override NodeApplicationParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeApplicationParameters parameters = new NodeApplicationParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.description = parametersDictionary["description"].ToString();
            parameters.version = parametersDictionary["version"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in NodeApplicationKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
