using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Model;
using ClientApp.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientApp.RabbitServer.DataAccess
{
    class Queues
    {
        private const string baseAddress = "http://10.0.19.244:15672/api/";
        private const string userName = "jssau4rmq";
        private const string password = "iaohmf";

        public static IEnumerable<QueueInfo> GetQueueInfos()
        {
            return GetQueueInfosInternal();
        }





        private static IEnumerable<QueueInfo> GetQueueInfosInternal()
        {
            List<QueueInfo> queues = new List<QueueInfo>();

            JArray queuesDataSet = RetrieveQueuesJson().Result;

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

            return queues;
        }

        private static async Task<JArray> RetrieveQueuesJson()
        {

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
                        string result = await response.Content.ReadAsStringAsync();

                        dynamic info = JsonConvert.DeserializeObject(result);

                        return info;
                    }
                }
            }
        }
    }
}
