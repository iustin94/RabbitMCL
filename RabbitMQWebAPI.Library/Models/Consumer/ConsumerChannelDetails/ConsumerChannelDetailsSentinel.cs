using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails
{
    class ConsumerChannelDetailsSentinel : Sentinel<ConsumerChannelDetailsInfo, ConsumerChannelDetailsParameters>
    {
      
        public override ConsumerChannelDetailsParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ConsumerChannelDetailsParameters parameters = new ConsumerChannelDetailsParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.number = parametersDictionary["number"].ToString();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.connection_name = parametersDictionary["connection_name"].ToString();
            parameters.peer_port = parametersDictionary["peer_port"].ToString();
            parameters.peer_host = parametersDictionary["peer_host"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ConsumerChannelDetailsKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
