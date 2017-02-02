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

namespace RabbitMQWebAPI.Library.DataAccess
{
    public static class Queues
    {
        /// <summary>
        /// A list of all queues.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<QueueInfo>> GetQueueInfos()
        {
            return await GetQueueInfosInternal();
        }

        // /api/queues	
        private static async Task<IEnumerable<QueueInfo>> GetQueueInfosInternal()
        {
            dynamic info;
            List<QueueInfo> queues = new List<QueueInfo>();

            var builder = new DbConnectionStringBuilder();
            builder.ConnectionString = ConfigurationManager.ConnectionStrings["HTTPapi"].ConnectionString;

            string baseAddress = builder["BaseAddress"].ToString();
            string userName = builder["username"].ToString();
            string password = builder["password"].ToString();

            using (var handler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential(userName: userName, password: password)
            })
            {
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(baseAddress) })
                {
                    using (
                        var response =
                            await
                                client.GetAsync("queues", HttpCompletionOption.ResponseContentRead)
                                    .ConfigureAwait(false))
                    {
                        string result = response.Content.ReadAsStringAsync().Result;

                        info = JsonConvert.DeserializeObject(result);

                        JArray queuesDataSet = info;

                        foreach (JObject queueData in queuesDataSet)
                        {
                            string name = queueData["name"].ToString();
                            string vhost = queueData["vhost"].ToString();
                            bool exclusive = queueData["exclusive"].ToString() == "True";
                            bool auto_delete = queueData["auto_delete"].ToString() == "True";
                            bool durable = queueData["durable"].ToString() == "True";
                            string state = queueData["state"].ToString();

                            QueueInfo queueInfo = new QueueInfo(name, state, exclusive, auto_delete, durable, vhost);
                            queues.Add(queueInfo);
                        }
                    }
                }
            }

            return queues;
        }

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
