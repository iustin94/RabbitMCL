using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Channel;
using RabbitMQWebAPI.Library.Models.Connection;
using RabbitMQWebAPI.Library.Models.Consumer.ChannelDetails;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public class ConsumerInfoSentinel : IParameterSentinel<ConsumerInfo, ConsumerInfoParameters>
    {
        public ConsumerInfo CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            ConsumerInfo toReturn;

            if (ValidateDictionary(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new ConsumerInfo(ParseDictionaryToParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        public ConsumerInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelDetailsSentinel sentinel = new ChannelDetailsSentinel();

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

        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
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
