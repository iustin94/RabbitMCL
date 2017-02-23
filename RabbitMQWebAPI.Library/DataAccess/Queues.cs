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
using RabbitMQWebAPI.Library.Models;
using RabbitMQWebAPI.Library.Models.Queue;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Queues
    {

        private DataFactory<QueueInfo> dataFactory;
        private QueueInfoSentinel sentinel;

        public Queues() {}

        public Queues(HttpClient client)
        {
            dataFactory = new DataFactory<QueueInfo>(client);
            sentinel = new QueueInfoSentinel();
        }

        /// <summary>
        /// A list of all queues.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<QueueInfo>> GetQueueInfos()
        {
            return await GetQueueInfosInternal();
        }

        // /api/queues	
        private async Task<IEnumerable<QueueInfo>> GetQueueInfosInternal()
        {
            return await dataFactory.BuildModels("queues", sentinel);
        }


        /*
         private static List<TResultModel> QueueInfoFactory<TResultModel>(JArray info, QueueInfoSentinel queueInfoSentinel)
             where TResultModel : new() 
        {
            List<TResultModel> queues = new List<TResultModel>();

            foreach (JObject queueData in info)
            {
                ISentinel<TResultModel, QueueInfoParameters> sentinel = queueInfoSentinel;
                TResultModel queue =
                    sentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(queueData.ToString()));

                queues.Add(queue);
            }
            return queues;
        }
         */


        /* TODO /api/queues/vhost	
         * A list of all queues in a given virtual host.
         */

        /* TODO /api/queues/vhost/name	
         * An individual queue. 
         */

        /* TODO /api/queues/vhost/name/bindings	
         * A list of all bindings on a given queue.
         */

    }
}
