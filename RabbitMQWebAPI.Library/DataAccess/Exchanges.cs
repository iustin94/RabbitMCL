using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models;
using RabbitMQWebAPI.Library.Models.Exchange;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Exchanges
    {

        /// <summary>
        /// A list of all exchanges.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfos()
        {
            return await GetExchangeInfosInternal();
        }

        /// <summary>
        /// An individual exchance
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public static async Task<ExchangeInfo> GetExchangeInfoOnVhost(string exchangeName, string vhost = "/")
        {
            return await GetExchangeInfoOnVhostInternal(exchangeName, vhost);
        }

        /// <summary>
        /// A list of all exchanges in a given virtual host.
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfosOnVhost(string vhost)
        {
            return await GetExchangeInfosForVhostInternal(vhost);
        }





        private static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfosInternal()
        {

            string result = await RMApiProvider.GetJson("exchanges");

            JArray info = JsonConvert.DeserializeObject<JArray>(result);
            List<ExchangeInfo> exchanges = new List<ExchangeInfo>();

            foreach (JObject exchangeData in info)
            {
                ExchangeInfoSentinel sentinel = new ExchangeInfoSentinel();

                ExchangeInfo exchange =
                    sentinel.CreateModel(
                        JsonConvert.DeserializeObject<Dictionary<string, object>>(exchangeData.ToString()));


            }

            return exchanges;
        }

        private static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfosForVhostInternal(String vhost)
        {

            vhost = WebUtility.UrlEncode(vhost);
            string result = await RMApiProvider.GetJson(String.Format("exchanges/{1}", vhost));

            JArray info = JsonConvert.DeserializeObject<JArray>(result);
            List<ExchangeInfo> exchanges = new List<ExchangeInfo>();

            foreach (JObject exchangeData in info)
            {
                ExchangeInfoSentinel sentinel = new ExchangeInfoSentinel();

                ExchangeInfo exchange =
                    sentinel.CreateModel(JsonConvert.DeserializeObject<
                                         Dictionary<string, object>>(exchangeData.ToString()));
                exchanges.Add(exchange);
            }

            return exchanges;
        }



        /* /api/exchanges/vhost/name	
         */
        private static async Task<ExchangeInfo> GetExchangeInfoOnVhostInternal(string exchangeName, string vhost)
        {
            exchangeName = WebUtility.UrlEncode(exchangeName);
            vhost = WebUtility.UrlEncode(vhost);

            string result = await RMApiProvider.GetJson(String.Format("exchanges/{0}/{1}", vhost, exchangeName));

            JObject info = JsonConvert.DeserializeObject<JObject>(result);

            
                ExchangeInfoSentinel sentinel = new ExchangeInfoSentinel();
                ExchangeInfo exchange =
                    sentinel.CreateModel(
                        JsonConvert.DeserializeObject<Dictionary<string, object>>(info.ToString()));
                
            
            return exchange;
        }
    }
}
