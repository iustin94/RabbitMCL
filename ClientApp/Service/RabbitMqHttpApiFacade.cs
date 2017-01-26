using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ClientApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientApp.Service
{
    static class RabbitMqHttpApiFacade
    {

        public static async void ServerOverview()
        {
            await RabbitMqHttpApiMeth.ServerOverview();
        }

        public static IEnumerable<QueueInfo> GetQueueInfos()
        {
            return RabbitMqHttpApiMeth.GetQueueInfos();
        }

        public static IEnumerable<ExchangeInfo> GetExchangeInfos()
        {
            return RabbitMqHttpApiMeth.GetExchangeInfos();
        }


        internal class RabbitMqHttpApiMeth
        {

            private const string baseAddress = "http://10.0.19.244:15672/api/";
            private const string userName = "jssau4rmq";
            private const string password = "iaohmf";

            public static async Task<XmlDocument> ServerOverview()
            {

                using (
                    var handler = new HttpClientHandler()
                    {
                        Credentials = new NetworkCredential(userName: userName, password: password)
                    })
                {
                    using (var client = new HttpClient(handler) { BaseAddress = new Uri(baseAddress) })
                    {
                        using (
                            var response =
                                await
                                    client.GetAsync("overview", HttpCompletionOption.ResponseContentRead)
                                        .ConfigureAwait(false)) // This doesn't block the main thread
                        {

                            string result = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(result);

                            dynamic info = JsonConvert.DeserializeObject(result);

                            // Unwrap json

                            return info;
                        }
                    }

                }

            }

            private static async Task<JArray> Queues()
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

            private static async Task<JArray> Exchanges()
            {
                using (var handler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential(userName: userName, password: password)
                })
                {
                    using (var client = new HttpClient(handler) {BaseAddress = new Uri(baseAddress)})
                    {
                        using (
                            var response =
                                await
                                    client.GetAsync("exchanges", HttpCompletionOption.ResponseContentRead)
                                        .ConfigureAwait(false))
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            dynamic info = JsonConvert.DeserializeObject(result);
                            return info;
                        }
                    }  
                }
            }


            public static IEnumerable<QueueInfo> GetQueueInfos()
            {
                List<QueueInfo> queues = new List<QueueInfo>();

                JArray queuesDataSet = Queues().Result;

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

            public static IEnumerable<ExchangeInfo> GetExchangeInfos()
            {
                List<ExchangeInfo> exchanges = new List<ExchangeInfo>();

                JArray exchangeDataSet = Exchanges().Result;

                return null;
            }







        }
    }
}