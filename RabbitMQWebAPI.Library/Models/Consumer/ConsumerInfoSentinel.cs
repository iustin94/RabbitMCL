using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Channel;
using RabbitMQWebAPI.Library.Models.Connection;
using RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public class ConsumerInfoSentinel : Sentinel<ConsumerInfo, ConsumerInfoParameters>
    {
        public override ConsumerInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ConsumerChannelDetailsSentinel sentinel = new ConsumerChannelDetailsSentinel();

            ConsumerInfoParameters parameters = new ConsumerInfoParameters();
            parameters.arguments = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            parameters.prefetch_count = Int32.Parse(parametersDictionary["prefetch_count"].ToString());
            parameters.ack_required = Boolean.Parse(parametersDictionary["ack_required"].ToString());
            parameters.exclusive = Boolean.Parse(parametersDictionary["exclusive"].ToString());
            parameters.consumer_tag = parametersDictionary["consumer_tag"].ToString();

            parameters.queue =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["queue"].ToString());

            parameters.channel_details = sentinel.CreateModel(
                JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["channel_details"].ToString()));

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ConnectionInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }
            
            return true;
        }
    }
}
