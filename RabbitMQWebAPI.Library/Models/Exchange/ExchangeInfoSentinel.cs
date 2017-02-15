using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Exchange.ExchangeMessageStats;

namespace RabbitMQWebAPI.Library.Models.Exchange
{
    public class ExchangeInfoSentinel : Sentinel<ExchangeInfo, ExchangeInfoParameters>
    {
        public override ExchangeInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ExchangeMessageStatsSentinel statsSentinel = new ExchangeMessageStatsSentinel();

            ExchangeInfoParameters parameters = new ExchangeInfoParameters();
            parameters.message_stats =
                statsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["message_stats"].ToString()));

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

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ExchangeInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
