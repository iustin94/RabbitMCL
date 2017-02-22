using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails;
using RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection;
using RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public class ChannelInfoSentinel : Sentinel<ChannelInfo, ChannelInfoParameters>
    {
      
        public override ChannelInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelConnectionDetailsSentinel channelConnectionDetailsSentinel = new ChannelConnectionDetailsSentinel();
            ChannelGarbageCollectionSentinel garbageCollectionSentinel = new ChannelGarbageCollectionSentinel();
            ChannelMessageStatsSentinel channelMessageStatsSentinel = new ChannelMessageStatsSentinel();

            ChannelInfoParameters parameters = new ChannelInfoParameters();

            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.number = Int32.Parse(parametersDictionary["number"].ToString());
            parameters.name = parametersDictionary["name"].ToString();
            parameters.node = parametersDictionary["node"].ToString();

            parameters.garbage_collection = garbageCollectionSentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["garbage_collection"].ToString()));

            parameters.reductions = Int32.Parse(parametersDictionary["reductions"].ToString());
            parameters.state = State.EvaluateState(parametersDictionary["state"].ToString());
            parameters.global_prefetch_count = Int32.Parse(parametersDictionary["global_prefetch_count"].ToString());
            parameters.prefetch_count = Int32.Parse(parametersDictionary["prefetch_count"].ToString());
            parameters.acks_uncommitted = Int32.Parse(parametersDictionary["acks_uncommitted"].ToString());
            parameters.messages_uncommitted = Int32.Parse(parametersDictionary["messages_uncommited"].ToString());
            parameters.messages_unconfirmed = Int32.Parse(parametersDictionary["messages_unconfirmed"].ToString());
            parameters.messages_unacknowledged = Int32.Parse(parametersDictionary["messages_unacknowledge"].ToString());
            parameters.consumer_count = Int32.Parse(parametersDictionary["consumer_count"].ToString());
            parameters.confirms = Boolean.Parse(parametersDictionary["confirms"].ToString());
            parameters.transactional = Boolean.Parse(parametersDictionary["transactional"].ToString());
            parameters.idle_since = parametersDictionary["idle_since"].ToString();

            parameters.reduction_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["reduction_details"].ToString());

            parameters.ChannelMessageStats =
                channelMessageStatsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["ChannelMessageStats"].ToString()));

            parameters.ChannelConnectionDetails =
                channelConnectionDetailsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["connection_details"].ToString()));

            return parameters;

        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ChannelInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }

    }
}
