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
        /// A list of all exchanges.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Exchange>> GetExchangeInfos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// An individual exchance
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public static async Task<Exchange> GetExchangeInfoOnVhost(string exchangeName, string vhost = "/")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// A list of all exchanges in a given virtual host.
        /// </summary>
        /// <param name="exchangeName"></param>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Exchange>> GetExchangeInfosOnVhost(string vhost)
        {
            throw new NotImplementedException();
        }

    }
}
