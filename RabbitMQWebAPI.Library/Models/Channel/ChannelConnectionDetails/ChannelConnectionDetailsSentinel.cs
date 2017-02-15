using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebApi.Library.Models.Binding;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails
{
    public class ChannelConnectionDetailsSentinel : Sentinel<ChannelConnectionDetails, ChannelConnectionDetailsParameters>
    {
        public override ChannelConnectionDetailsParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelConnectionDetailsParameters parameters = new ChannelConnectionDetailsParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.peer_host = parametersDictionary["peer_host"].ToString();
            parameters.peer_port = parametersDictionary["peer_port"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {

            foreach (string key in ChannelConnectionDetailsKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }
            return true;
        }
    }
}
