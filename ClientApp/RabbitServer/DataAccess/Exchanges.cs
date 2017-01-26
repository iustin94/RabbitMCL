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
    class Exchanges
    {
        private const string baseAddress = "http://10.0.19.244:15672/api/";
        private const string userName = "jssau4rmq";
        private const string password = "iaohmf";

        public static IEnumerable<ExchangeInfo> GetExchangeInfos()
        {
            return GetExchangeInfosInternal();
        }


        private static async Task<JArray> GetExchangesJson()
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

        public static IEnumerable<ExchangeInfo> GetExchangeInfosInternal()
        {
            List<ExchangeInfo> exchanges = new List<ExchangeInfo>();

            JArray exchangeDataSet = GetExchangesJson().Result;

            foreach (JObject exchangeData in exchangeDataSet)
            {

            }

            return null;
        }


    }
}
