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
using RabbitMQWebApi.Library.Models;
using RabbitMQWebApi.Library.Models.Binding;
using RabbitMQWebAPI.Library.Models.Binding;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public static class Bindings
    {

        public static Task<IEnumerable<BindingInfo>> GetBindingInfos()
        {
            return GetBindingInfosInternal();
        }


        // /api/bindings
        private static async Task<IEnumerable<BindingInfo>> GetBindingInfosInternal()
        {
            dynamic info;
            List<BindingInfo> bindings = new List<BindingInfo>();

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
                    using (var response = await client.GetAsync("bindings", HttpCompletionOption.ResponseContentRead)
                        .ConfigureAwait(false))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        info = JsonConvert.DeserializeObject(result);

                        JArray bindingsDataSet = info;

                        foreach (JObject bindingData in bindingsDataSet)
                        {
                            var source = bindingData["source"].ToString();
                            var vhost = bindingData["vhost"].ToString();
                            var destination = bindingData["destination"].ToString();
                            var destination_type = bindingData["destination_type"].ToString();
                            var routing_key = bindingData["routing_key"].ToString();
                            var properties_key = bindingData["properties_key"].ToString();

                            Dictionary<string, string> arguments =
                                JsonConvert.DeserializeObject<Dictionary<string, string>>(bindingData["arguments"].ToString());

                            BindingInfoSentinel sentinel = new BindingInfoSentinel();

                            BindingInfo binding = sentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string,object>>(bindingData.ToString()));
                            bindings.Add(info);
                        }
                    }
                }
            }

            return bindings;
        }


        /* TODO /api/bindings/vhost 
         * A list of all bindings in a given virtual host.
         * */

        /* TODO /api/bindings/vhost/e/exchange/q/queue
         * A list of all bindings between an exchange and a queue. Remember, an exchange and a queue can be bound together many times! 
         * To create a new binding, POST to this URI. You will need a body looking something like this:
         * 
         * EX: {"routing_key":"my_routing_key","arguments":{}}
         *
         * All keys are optional. The response will contain a Location header telling you the URI of your new binding.
         */

        /* TODO /api/bindings/vhost/e/exchange/q/queue/props	
         * 
         * An individual binding between an exchange and a queue. The props part of the URI is a "name" for the binding composed of its routing key and a hash of its arguments.
         */

        /* TODO /api/bindings/vhost/e/source/e/destination	
         * A list of all bindings between two exchanges. Similar to the list of all bindings between an exchange and a queue, above.
         */

        /* TODO /api/bindings/vhost/e/source/e/destination/props	
         * An individual binding between two exchanges. Similar to the individual binding between an exchange and a queue, above.
         */

    }
}
