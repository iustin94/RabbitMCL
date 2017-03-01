using RabbitMQWebAPI.Library.Models.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Consumers
    {
        private ConsumerSentinel sentinel = new ConsumerSentinel();
        private DataFactory<Consumer> dataFactory;


        public Consumers(HttpClient client)
        {
            dataFactory = new DataFactory<Consumer>(client);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Consumer&gt; of all consumers.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Consumer>> GetConsumers()
        {
            return await dataFactory.BuildModels("/api/consumers", sentinel);
        }


        /// <summary>
        /// Returns a IEnumerable&lt;Consumer&gt; of all consumers in a vhost
        /// </summary>
        /// <param name="vhost"></param>
        /// <returns></returns>

        public async Task<IEnumerable<Consumer>> GetConsumersOnVhost(string vhost)
        {
            vhost = WebUtility.UrlEncode(vhost);

            return await dataFactory.BuildModels(String.Format("/api/consumers/{0}", vhost), sentinel);
        }
    }
}
