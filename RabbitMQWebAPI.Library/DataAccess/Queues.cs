using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Data.Common;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;
using RabbitMQWebAPI.Library.Models;
using RabbitMQWebAPI.Library.Models.Queue;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Queues
    {

        private DataFactory<Queue> dataFactory;
        private QueueSentinel sentinel;

        public Queues(HttpClient client)
        {
            dataFactory = new DataFactory<Queue>(client);
            sentinel = new QueueSentinel();
        }
      
        /// <summary>
        /// Returns a IEnumerable&lt;Queue&gt; object with all the queues.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Queue>> GetQueues()
        {
            // /api/queues	

            return await dataFactory.BuildModels("api/queues", sentinel);
        }

        /// <summary>
        /// Returns a IEnumerable &lt;Queue&gt; object on the given vhost.
        /// </summary>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Queue>> GetQueuesOnVhost(string vhost)
        {
            vhost = WebUtility.UrlEncode(vhost);

            return await dataFactory.BuildModels(String.Format("api/queues/{0}", vhost), sentinel);
        }
         /// <summary>
         /// Returns a &lt;Queue&gt; object on the specified vhost
         /// </summary>
         /// <param name="vhost"></param>
         /// <param name="name"></param>
         /// <returns></returns>

        public async Task<Queue> GetQueueOnVhost(string vhost, string queueName)
        {
            vhost = WebUtility.UrlEncode(vhost);
            queueName = WebUtility.UrlEncode(queueName);

            return await dataFactory.BuildModel(String.Format("api/queues/{0}/{1}", vhost, queueName), sentinel);
        }

       

    }
}
