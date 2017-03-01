using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;
using RabbitMQWebAPI.Library.Models.Connection;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Connections
    {
        private ConnectionSentinel sentinel = new ConnectionSentinel();
        private DataFactory<Connection> dataFactory;

        public Connections(HttpClient client)
        {
            dataFactory = new DataFactory<Connection>(client);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Connection&gt; of all open connections.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Connection>>  GetConnections()
        {
            return await dataFactory.BuildModels("/api/connections", sentinel);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Connection&gt; of all open connections in a specific vhost.
        /// </summary>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Connection>> GetConnectionsOnVhost(string vhost)
        {
            vhost = WebUtility.UrlEncode(vhost);

            return await dataFactory.BuildModels(String.Format("/api/vhosts/{0}/connections", vhost), sentinel);
        }

        /// <summary>
        /// Returns an individual Connection by name.
        /// </summary>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public async Task<Connection> GetConnectionByName(string name)
        {
            name = WebUtility.UrlEncode(name);

            return await dataFactory.BuildModel(String.Format("/api/connections/{0}", name), sentinel);
        }

     
    }
}
