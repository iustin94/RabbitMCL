using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Exchange.ExchangeMessageStats;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Exchange
{
    public class ExchangeInfoSentinel : Sentinel<Exchange>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ExchangeMessageStatsSentinel statsSentinel = new ExchangeMessageStatsSentinel();

            Exchange parameters = new Exchange();
            parameters.message_stats = (ExchangeMessageStats.ExchangeMessageStats)
                statsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["message_stats"].ToString()), new ExchangeMessageStats.ExchangeMessageStats());

            parameters.name = parametersDictionary["name"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.type = parametersDictionary["type"].ToString();
            parameters.durable = Boolean.Parse(parametersDictionary["durable"].ToString());
            parameters.auto_delete = Boolean.Parse(parametersDictionary["auto_delete"].ToString());
            parameters._internal = Boolean.Parse(parametersDictionary["internal"].ToString());
            parameters.arguments =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());

            return parameters;
        }
    }
}
