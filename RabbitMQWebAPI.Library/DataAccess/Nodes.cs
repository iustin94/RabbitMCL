using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Node;
using RabbitMQWebAPI.Library.Models.Node.NodeClusterLink.NodeClusterLinkStats;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Nodes
    {
        private NodeSentinel sentinel = new NodeSentinel();
        private DataFactory<Node> dataFactory;

        public Nodes(HttpClient client)
        {
            dataFactory = new DataFactory<Node>(client);
        }

       /// <summary>
       /// Returns a IEnumerable&lt;Node&gt; of Nodes in the cluster
       /// </summary>
       /// <returns></returns>
        public async Task<IEnumerable<Node>> GetNodes()
        {
            return await dataFactory.BuildModels("/api/nodes", sentinel);
        }


        /*TODO /api/nodes/name	
         * An individual node in the RabbitMQ cluster. Add "?memory=true" to 
         * get memory statistics, and "?binary=true" to get a breakdown of binary memory use (may be expensive if there are many small binaries in the system).
         */

        /// <summary>
        /// Returns an individual Node by name.
        /// </summary>
        /// <returns></returns>
        public async Task<Node> GetNodeByName(string name)
        {
            name = WebUtility.UrlEncode(name);
            
            return await dataFactory.BuildModel(String.Format("/api/node/{0}", name), sentinel);
        }

    }
}
