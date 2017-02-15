using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink
{
    public class NodeClusterLinkSentinel : Sentinel<NodeClusterLink, NodeClusterLinkParameters>
    {
        public override NodeClusterLinkParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeClusterLinkStatsSentinel statsSentinel = new NodeClusterLinkStatsSentinel();

            NodeClusterLinkParameters parameters = new NodeClusterLinkParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.peer_addr = parametersDictionary["peer_addr"].ToString();
            parameters.peer_port = Int32.Parse(parametersDictionary["peer_port"].ToString());
            parameters.sock_addr = parametersDictionary["sock_addr"].ToString();
            parameters.sock_port = Int32.Parse(parametersDictionary["sock_port"].ToString());
            parameters.stats =statsSentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["stats"].ToString()));

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in NodeClusterLinkKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
