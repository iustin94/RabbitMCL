using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Channel.ConnectionDetails;
using RabbitMQWebAPI.Library.Models.Channel.GarbageCollection;
using RabbitMQWebAPI.Library.Models.Channel.MessageStats;

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public class ChannelInfoSentinel : IParameterSentinel<ChannelInfo, ChannelInfoParameters>
    {
        public ChannelInfo CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            ChannelInfo toReturn;

            if (ValidateDictionary(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new ChannelInfo(ParseDictionaryToParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        public ChannelInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ConnectionDetailsSentinel connectionDetailsSentinel = new ConnectionDetailsSentinel();
            GarbageCollectionSentinel garbageCollectionSentinel = new GarbageCollectionSentinel();
            MessageStatsSentinel messageStatsSentinel = new MessageStatsSentinel();

            ChannelInfoParameters parameters = new ChannelInfoParameters();

            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.number = Int32.Parse(parametersDictionary["number"].ToString());
            parameters.name = parametersDictionary["name"].ToString();
            parameters.node = parametersDictionary["node"].ToString();

            parameters.garbade_collection = garbageCollectionSentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["garbage_collection"].ToString()));

            parameters.reductions = Int32.Parse(parametersDictionary["reductions"].ToString());
            parameters.state = State.EvaluateState(parametersDictionary["state"].ToString());
            parameters.global_prefetch_count = Int32.Parse(parametersDictionary["global_prefetch_count"].ToString());
            parameters.prefetch_count = Int32.Parse(parametersDictionary["prefetch_count"].ToString());
            parameters.acks_uncommitted = Int32.Parse(parametersDictionary["acks_uncommitted"].ToString());
            parameters.messages_uncommitted = Int32.Parse(parametersDictionary["messages_uncommited"].ToString());
            parameters.messages_unconfirmed = Int32.Parse(parametersDictionary["messages_unconfirmed"].ToString());
            parameters.messages_unacknowledge = Int32.Parse(parametersDictionary["messages_unacknowledge"].ToString());
            parameters.consumer_count = Int32.Parse(parametersDictionary["consumer_count"].ToString());
            parameters.confirms = Boolean.Parse(parametersDictionary["confirms"].ToString());
            parameters.transactional = Boolean.Parse(parametersDictionary["transactional"].ToString());
            parameters.idle_since = parametersDictionary["idle_since"].ToString();

            parameters.reduction_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["reduction_details"].ToString());

            parameters.message_stats =
                messageStatsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["message_stats"].ToString()));

            parameters.connection_details =
                connectionDetailsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["connection_details"].ToString()));

            return parameters;

        }

        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
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
