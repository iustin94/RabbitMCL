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

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Bindings
    {

        public static Task<IEnumerable<BindingInfo>> GetBindingInfos()
        {
            return GetBindingInfosInternal();
        }

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

                            bindings.Add(new BindingInfo(source, vhost, destination, destination_type, routing_key, arguments, properties_key));
                        }
                    }
                }
            }

            return bindings;
        }

    }
}
