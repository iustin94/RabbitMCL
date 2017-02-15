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
using RabbitMQWebAPI.Library.Models;
using RabbitMQWebAPI.Library.Models.Exchange;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Exchanges
    {


        /// <summary>
        /// An individual exchance
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public static async Task<ExchangeInfo> GetExchangeInfo(string exchangeName, string vhost = "/")
        {
            return await GetExchangeInfoInternal(exchangeName, vhost);
        }

        /* /api/exchanges/vhost/name	
         */
        private static async Task<ExchangeInfo> GetExchangeInfoInternal(string exchangeName, string vhost)
        {
            dynamic exchangeData;

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
                    string vhostArgument = WebUtility.UrlEncode(vhost);
                    string exchangeNameArgument = WebUtility.UrlEncode(exchangeName);
                    using (
                        var response =
                            await
                                client.GetAsync(String.Format("exchanges/{0}/{1}", vhostArgument, exchangeNameArgument), //Encode "/" character
                                        HttpCompletionOption.ResponseContentRead)
                                    .ConfigureAwait(false))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        exchangeData = JsonConvert.DeserializeObject(result);

                        var name = exchangeData["name"].ToString();
                        var e_vhost = exchangeData["vhost"].ToString();
                        var type = exchangeData["type"].ToString();
                        bool durable = exchangeData["durable"].ToString() == "true";
                        bool auto_delete = exchangeData["auto_delete"].ToString() == "true";
                        bool internal_exchange = exchangeData["internal"].ToString() == "true";

                        Dictionary<string, object> arguments =
                            JsonConvert.DeserializeObject<Dictionary<string, object>>(
                                exchangeData["parametersDictionary"].ToString());

                        ExchangeInfoSentinel sentinel = new ExchangeInfoSentinel();

                        return sentinel.CreateModel(arguments);
                    }
                }
            }
        }



        /// <summary>
        /// A list of all exchanges.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfos()
        {
            return await GetExchangeInfosInternal();
        }

        // /api/exchanges	
        private static async Task<IEnumerable<ExchangeInfo>> GetExchangeInfosInternal()
        {
            dynamic info;
            List<ExchangeInfo> exchanges = new List<ExchangeInfo>();


            var builder = new DbConnectionStringBuilder();
            builder.ConnectionString = ConfigurationManager.ConnectionStrings["RabbitMQDevelopmentClusterAddress"].ConnectionString;

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
                                client.GetAsync("exchanges", HttpCompletionOption.ResponseContentRead)
                                    .ConfigureAwait(false))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        info = JsonConvert.DeserializeObject(result);

                        JArray exchangeDataSet = info.Result;

                        foreach (JObject exchangeData in exchangeDataSet)
                        {
                            var name = exchangeData["name"].ToString();
                            var vhost = exchangeData["vhost"].ToString();
                            var type = exchangeData["type"].ToString();
                            bool durable = exchangeData["durable"].ToString() == "true";
                            bool auto_delete = exchangeData["auto_delete"].ToString() == "true";
                            bool internal_exchange = exchangeData["internal"].ToString() == "true";

                            Dictionary<string, object> arguments =
                                JsonConvert.DeserializeObject<Dictionary<string, object>>(
                                    exchangeData["parametersDictionary"].ToString());

                            ExchangeInfoSentinel sentinel = new ExchangeInfoSentinel();

                            exchanges.Add(sentinel.CreateModel(arguments));
                        }

                    }
                }
            }

            return exchanges;
        }


        /*TODO /api/exchanges/vhost	
         * A list of all exchanges in a given virtual host.
         */

        /*TODO /api/exchanges/vhost/name/bindings/source	
         * A list of all bindings in which a given exchange is the source.
         */

        /*TODO /api/exchanges/vhost/name/bindings/destination	
         * A list of all bindings in which a given exchange is the destination.
         */
      
    }
}
