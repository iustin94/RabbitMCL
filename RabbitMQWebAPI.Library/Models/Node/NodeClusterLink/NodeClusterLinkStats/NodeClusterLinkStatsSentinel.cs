using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats
{
    public class NodeClusterLinkStatsSentinel : Sentinel<NodeClusterLinkStats>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeClusterLinkStats parameters = new NodeClusterLinkStats();
            parameters.send_bytes = Int32.Parse(parametersDictionary["send_bytes"].ToString());
            parameters.send_bytes_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["send_bytes_details"].ToString());

            return parameters;
        }
        
    }
}
