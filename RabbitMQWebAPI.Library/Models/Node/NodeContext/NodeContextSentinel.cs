using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Node.NodeContext
{
    public class NodeContextSentinel: Sentinel<NodeContext, NodeContextParameters>
    {
        public override NodeContextParameters ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary)
        {
            NodeContextParameters parameters = new NodeContextParameters();
            parameters.port = parametersDictionary["port"].ToString();
            parameters.path = parametersDictionary["path"].ToString();
            parameters.description = parametersDictionary["description"].ToString();

            return parameters;
        }

        public override bool ValidateDictionary(IDictionary<string, object> parametersDictionary)
        {
            foreach (string key in NodeContextKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);   
            }

            return true;
        }
    }
}
