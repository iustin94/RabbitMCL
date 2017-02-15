using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats
{
    public class NodeClusterLinkStatsSentinel : Sentinel<NodeClusterLinkStats, NodeClusterLinkStatsParameters>
    {
        public override NodeClusterLinkStatsParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeClusterLinkStatsParameters parameters = new NodeClusterLinkStatsParameters();
            parameters.send_bytes = Int32.Parse(parametersDictionary["send_bytes"].ToString());
            parameters.send_bytes_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["send_bytes_details"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in NodeClusterLinkStatsKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
