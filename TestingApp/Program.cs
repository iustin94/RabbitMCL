using RabbitMQWebAPI.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Channel;
using RabbitMQWebAPI.Library.Models.Connection;
using RabbitMQWebAPI.Library.Models.Definition;

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
            var manager = new Extentions(client);

            //var tmp1 = bindings.GetBindingInfos().Result;
            //var tmp2 = bindings.GetBindingInfosBetweenExchangeAndQueueOnVhost("ha-exchange-MainExchange", "ha.queue1", "/"); // Should return 1 binding
            //var tmp3 = bindings.GetBindingInfosForExchangeOnVhost("/", "ha.exchange-alternativeExchange");
            //var tmp4 = bindings.GetBindingInfosForVhost("/");
            //var tmp5 = bindings.GetBindingInfosToExchangeOnVhost("ha.exchange-alternativeExchange", "/").Result;


            var tmp1 = manager.GetExtentions().Result;

            //foreach (var idk in tmp1)
            //{
            //    Console.WriteLine(idk.ToString());
            //}

            //Queues queues = new Queues(client);

            //var tmp = queues.GetQueueInfos().Result;

            Console.ReadLine();
        }
    }
}
