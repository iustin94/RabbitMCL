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
using RabbitMQWebAPI.Library.DataAccess.DataFactory;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Binding;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Bindings
    {
        private DataFactory<Binding> dataFactory;
        private BindingSentinel sentinel;

        public Bindings() { }

        /// <summary>
        /// Takes a HttpClient object to use for api calls.
        /// </summary>
        /// <param name="client"></param>
        public Bindings(HttpClient client)
        {
            dataFactory = new DataFactory<Binding>(client);
            sentinel = new BindingSentinel();
        }


        /// <summary>
        /// Returns a IEnumerable&lt;Binding&gt; of all bindings in the server.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Binding>> GetBindingInfos()
        {
            //return await dataFactory.BuildModels("api/bindings", this.sentinel);
            return await dataFactory.BuildModels("api/badcall", this.sentinel);
        }


        /// <summary>
        /// Returns a IEnumerable&lt;Binding&gt; of Bindings in a given virtual host 
        /// </summary>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Binding>> GetBindingInfosForVhost(string vhost)
        {
            vhost = WebUtility.UrlEncode(vhost);

            List<Binding> bindings =
                await dataFactory.BuildModels(string.Format("/api/bindings/{0}", vhost), sentinel);

            return bindings;
        }


        ///// <summary>
        ///// Returns a IEnumerable&lt;Binding&gt; of all bindings between an exchange and a queue. Remember, an exchange and a queue can be bound together many times! To create a new binding, POST to this URI. You will need a body looking something like this:
        ///// </summary>
        ///// <param name="exchange"></param>
        ///// <param name="queue"></param>
        ///// <param name="vhost"></param>
        ///// <returns></returns>
        public async Task<IEnumerable<Binding>> GetBindingInfosBetweenExchangeAndQueueOnVhost(
            string exchange, string queue, string vhost)
        {
            exchange = WebUtility.UrlEncode(exchange);
            queue = WebUtility.UrlEncode(queue);
            vhost = WebUtility.UrlEncode(vhost);

            List<Binding> bindings =
                await dataFactory.BuildModels(string.Format("/api/bindings/{0}/e/{1}/q/{q}"), sentinel);
            return bindings;
        }


        ///// <summary>
        ///// Returns a IEnumerable&lt;Binding&gt; of all bindings between two exchanges. Similar to the list of all bindings between an exchange and a queue, above.
        ///// </summary>
        ///// <param name="vhost"></param>
        ///// <param name="sourceExchange"></param>
        ///// <param name="destinationExchange"></param>
        ///// <returns></returns>
        public async Task<IEnumerable<Binding>> GetBindingInfosBetweenTwoExchangesOnVhost(string vhost,
            string sourceExchange, string destinationExchange)
        {
            vhost = WebUtility.UrlEncode(vhost);
            sourceExchange = WebUtility.UrlEncode(sourceExchange);
            destinationExchange = WebUtility.UrlEncode(destinationExchange);

            List<Binding> bindings =
                await
                    dataFactory.BuildModels(String.Format("/api/bindings/{0}/e/{1}/e/{2}", vhost, sourceExchange,
                        destinationExchange), sentinel);

            return bindings;
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Binding&gt; in which the given exchange is the source.
        /// </summary>
        /// <param name="vhost"></param>
        /// <param name="sourceExchange"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Binding>> GetBindingInfosForExchangeOnVhost(string vhost,
            string sourceExchange)
        {
            vhost = WebUtility.UrlEncode(vhost);
            sourceExchange = WebUtility.UrlEncode(sourceExchange);

            List<Binding> bindings = await dataFactory.BuildModels(String.Format("/api/exchanges/{0}/{1}/bindings/source", vhost, sourceExchange), sentinel);

            return bindings;
        }

        ///// <summary>
        ///// Returns a IEnumerable&lt;Binding&gt in which the given exchange is the destination.
        ///// </summary>
        ///// <returns></returns>
        public async Task<IEnumerable<Binding>> GetBindingInfosToExchangeOnVhost(string vhost, string destinationExchange)
        {
            vhost = WebUtility.UrlEncode(vhost);
            destinationExchange = WebUtility.UrlEncode(destinationExchange);

            return
                  await dataFactory.BuildModels(String.Format("api/exchanges/{0}/{1}/bindings/destination", vhost, destinationExchange), this.sentinel);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Binding&gt; object of all bindings on a given queue.
        /// </summary>
        /// <param name="vhost"></param>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Binding>> GetBindingsOnQueue(string vhost, string queueName)
        {
            vhost = WebUtility.UrlEncode(vhost);
            queueName = WebUtility.UrlEncode(queueName);

            return await dataFactory.BuildModels(String.Format("/api/queues/{0}/{1}/bindings", vhost, queueName), sentinel);
        }

        /// <summary>
        /// Returns a Binding object for an individual binding between two exchanges. Similar to the individual binding between an exchange and a queue, above.
        /// </summary>
        /// <param name="vhost"></param>
        /// <param name="sourceExchange"></param>
        /// <param name="destinationExchange"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        public async Task<Binding> GetBindingBetweenTwoExchanges(string vhost, string sourceExchange,
            string destinationExchange, string props)
        {
            vhost = WebUtility.UrlEncode(vhost);
            sourceExchange = WebUtility.UrlEncode(sourceExchange);
            destinationExchange = WebUtility.UrlEncode(destinationExchange);
            props = WebUtility.UrlEncode(props);

            return
                await
                    dataFactory.BuildModel(
                        string.Format("/api/bindings/{0}/e/{1}/e/{2}/{3}", vhost, sourceExchange, destinationExchange,
                            props), sentinel);

        }


        /// <summary>
        /// Returns a Binding object between an exchange and a queue.The props part of the URI is a "name" for the binding composed of its routing key and a hash of its arguments.
        /// </summary>
        /// <param name="vhost"></param>
        /// <param name="exchangeName"></param>
        /// <param name="queueName"></param>
        /// <param name="props"></param>
        /// <returns></returns>

        public async Task<Binding> GetBindingBetweenExchangeAndQueue(string vhost, string exchangeName,
           string queueName, string props)
        {
            vhost = WebUtility.UrlEncode(vhost);
            exchangeName = WebUtility.UrlEncode(exchangeName);
            queueName = WebUtility.UrlEncode(queueName);
            props = WebUtility.UrlEncode(props);

            return await dataFactory.BuildModel(string.Format("/api/bindings/{0}/e/{1}/q/{2}/{3}"), sentinel);
        }
    }
}
