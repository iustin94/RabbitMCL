using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess;
using RabbitMQWebAPI.Library.Models;
using RabbitMQWebAPI.Library.Models.Binding;
using RabbitMQWebAPI.Library.Models.Exchange;

namespace RabbitMQWebAPI.Library.Service
{
    public class ExchangesQueues
    {

        /// <summary>
        /// Returns the exchange that has a binding to the specified queueName or NULL if no such exchange exists.
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public async Task<ExchangeInfo> getExchangeForQueue(string queueName)
        {
            Bindings bindingsFactory = new Bindings();

            IEnumerable<BindingInfo> bindings = await bindingsFactory.GetBindingInfos();

            foreach (var binding in bindings)
            {
                if (binding.destination == queueName && binding.source != String.Empty)
                {
                   // return Exchanges.GetExchangeInfos().Result;
                }
            }

            return null;
        }
    }
}
