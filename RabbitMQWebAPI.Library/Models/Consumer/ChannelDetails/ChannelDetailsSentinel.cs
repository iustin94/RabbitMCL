using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Consumer.ChannelDetails
{
    class ChannelDetailsSentinel : IParameterSentinel<ChannelDetailsInfo, ChannelDetailsParameters>
    {
        public ChannelDetailsInfo CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            ChannelDetailsInfo toReturn;

            if (ValidateDictionary(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new ChannelDetailsInfo(ParseDictionaryToParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        public ChannelDetailsParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelDetailsParameters parameters = new ChannelDetailsParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.number = parametersDictionary["number"].ToString();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.connection_name = parametersDictionary["connection_name"].ToString();
            parameters.peer_port = parametersDictionary["peer_port"].ToString();
            parameters.peer_host = parametersDictionary["peer_host"].ToString();

            return parameters;
        }

        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ChannelDetailsKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
