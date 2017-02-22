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
using RabbitMQWebApi.Library.Models.Binding;
using RabbitMQWebAPI.Library.Models.Binding;

namespace RabbitMQWebAPI.Library.Interfaces
{
    public class RMApiProvider
    {
        public static async Task<string> GetJson(string path)
        {
            string result;
          

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
                    using (var response = await client.GetAsync(path, HttpCompletionOption.ResponseContentRead)
                        .ConfigureAwait(false))
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }
                }
            }

            return result;
        }

    }
}
