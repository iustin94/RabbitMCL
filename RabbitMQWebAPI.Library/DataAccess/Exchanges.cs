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
using RabbitMQWebAPI.Library.Models.Exchange.ExchangeMessageStats;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Exchanges
    {
        private ExchangeSentinel sentinel = new ExchangeSentinel();
        private DataFactory<Exchange> dataFactory;

        public Exchanges(HttpClient client)
        {
            dataFactory = new DataFactory<Exchange>(client);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Echange&gt; of all exchanges.
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<Exchange>> GetExchanges()
        {
            return await dataFactory.BuildModels("/api/exchanges", sentinel);
        }

        /// <summary>
        ///  Returns an individual Exchange
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public async Task<Exchange> GetExchangeInfoOnVhost(string exchangeName, string vhost)
        {
            exchangeName = WebUtility.UrlEncode(exchangeName);
            vhost = WebUtility.UrlEncode("vhost");

            return await dataFactory.BuildModel(String.Format("/api/exchanges/{0}/{1}", vhost, exchangeName), sentinel);
        }

        /// <summary>
        /// A list of all exchanges in a given virtual host.
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public  async Task<IEnumerable<Exchange>> GetExchangeInfosOnVhost(string vhost)
        {
            vhost = WebUtility.UrlEncode(vhost);

            return await dataFactory.BuildModels(String.Format("/api/exchanges/{0}", vhost), sentinel);
        }

    }
}
