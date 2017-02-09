using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebApi.Library.Models;
using RabbitMQWebApi.Library.Models.Binding;
using RabbitMQWebAPI.Library.DataAccess;
using RabbitMQWebAPI.Library.Models;

namespace RabbitMQWebAPI.Library.Service
{
    public class ExchangesQueues
    {

        /// <summary>
        /// Returns the exchange that has a binding to the specified queueName or NULL if no such exchange exists.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public static async Task<ExchangeInfo> getExchangeForQueue(string queueName)
        {
            IEnumerable<BindingInfo> bindings = await Bindings.GetBindingInfos();

            foreach (var binding in bindings)
            {
                if (binding.destination == queueName && binding.source != String.Empty)
                {
                    return Exchanges.GetExchangeInfo(binding.source).Result;
                }
            }

            return null;
        }
    }
}
