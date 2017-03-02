using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;
using RabbitMQWebAPI.Library.Models.Vhost;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Vhosts
    {
        private VhostSentinel sentinel = new VhostSentinel();
        private DataFactory<Vhost> dataFactory;


        public Vhosts(HttpClient client)
        {
            dataFactory = new DataFactory<Vhost>(client);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Vhost&gt; of all vhosts
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Vhost>> GetVhosts()
        {
            return await dataFactory.BuildModels("/api/vhosts", sentinel);
        }

        /// <summary>
        /// Returns a Vhost by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Vhost> GetVhostByName(string name)
        {
            name = WebUtility.UrlEncode(name);

            return await dataFactory.BuildModel(String.Format("/api/vhosts/{0}", name), sentinel);
        }

    }
}
