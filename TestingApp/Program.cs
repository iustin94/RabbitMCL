using RabbitMQWebAPI.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential("jssau4rmq", "iaohmf");

            HttpClient client = new HttpClient(handler, true);
            client.BaseAddress = new Uri("http://nc-mso-test01:15672/");

            Bindings bindings = new Bindings(client);

            //var tmp = bindings.GetBindingInfosToExchangeOnVhost("ha.exchange-alternativeExchange", "/").Result;

            //foreach (var idk in tmp)
            //{
            //    Console.WriteLine(idk.ToString());
            //}

            Queues queues = new Queues(client);

            var tmp = queues.GetQueueInfos().Result;

            foreach (var x in tmp)
            {
                Console.WriteLine(JsonConvert.SerializeObject(x));
            }


            Console.ReadLine();
        }
    }
}
