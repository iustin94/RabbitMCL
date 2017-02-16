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
                            Dictionary<string, string> arguments =
                               JsonConvert.DeserializeObject<Dictionary<string, string>>(queueData["arguments"].ToString());

                            QueueInfoSentinel sentinel = new QueueInfoSentinel();

                            QueueInfo binding = sentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(queueData.ToString()));
                            queues.Add(info);
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
