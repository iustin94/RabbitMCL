using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink
{
    public class NodeClusterLinkSentinel : Sentinel<NodeClusterLink>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeClusterLinkStatsSentinel statsSentinel = new NodeClusterLinkStatsSentinel();

            NodeClusterLink parameters = new NodeClusterLink();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.peer_addr = parametersDictionary["peer_addr"].ToString();
            parameters.peer_port = double.Parse(parametersDictionary["peer_port"].ToString());
            parameters.sock_addr = parametersDictionary["sock_addr"].ToString();
            parameters.sock_port = double.Parse(parametersDictionary["sock_port"].ToString());
            parameters.stats =
                (NodeClusterLinkStats.NodeClusterLinkStats)
                statsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["stats"].ToString()),
                    new NodeClusterLinkStats.NodeClusterLinkStats());

            return parameters;
        }

    }
}
