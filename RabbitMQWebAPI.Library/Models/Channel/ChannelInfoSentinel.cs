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
            if (!parametersDictionary.ContainsKey("vhost"))
                throw new DictionaryMissingArgumentException("vhost");

            if (!parametersDictionary.ContainsKey("user"))
                throw new DictionaryMissingArgumentException("user");

            if (!parametersDictionary.ContainsKey("number"))
                throw new DictionaryMissingArgumentException("number");

            if (!parametersDictionary.ContainsKey("name"))
                throw new DictionaryMissingArgumentException("name");

            if (!parametersDictionary.ContainsKey("node"))
                throw new DictionaryMissingArgumentException("node");

            if (!parametersDictionary.ContainsKey("garbage_collection"))
                throw new DictionaryMissingArgumentException("garbage_collection");

            if (!parametersDictionary.ContainsKey("reductions"))
                throw new DictionaryMissingArgumentException("reductions");

            if (!parametersDictionary.ContainsKey("State"))
                throw new DictionaryMissingArgumentException("State");

            if (!parametersDictionary.ContainsKey("global_prefetch_count"))
                throw new DictionaryMissingArgumentException("global_prefectch_count");

            if (!parametersDictionary.ContainsKey("prefetch_count"))
                throw new DictionaryMissingArgumentException("prefetch_count");

            if (!parametersDictionary.ContainsKey("acks_uncomitted"))
                throw new DictionaryMissingArgumentException("acks_uncomitted");

            if (!parametersDictionary.ContainsKey("messages_unconfirmed"))
                throw new DictionaryMissingArgumentException("messages_unconfirmed");

            if (!parametersDictionary.ContainsKey("messages_unacknowledge"))
                throw new DictionaryMissingArgumentException("messages_unacknowledge");

            if (!parametersDictionary.ContainsKey("consumer_count"))
                throw new DictionaryMissingArgumentException("consumer_count");

            if (!parametersDictionary.ContainsKey("confirms"))
                throw new DictionaryMissingArgumentException("confirms");

            if (!parametersDictionary.ContainsKey("transactional"))
                throw new DictionaryMissingArgumentException("transactional");

            if (!parametersDictionary.ContainsKey("idle_since"))
                throw new DictionaryMissingArgumentException("idle_since");

            if (!parametersDictionary.ContainsKey("reduction_details"))
                throw new DictionaryMissingArgumentException("reduction_details");

            if (!parametersDictionary.ContainsKey("message_stats"))
                throw new DictionaryMissingArgumentException("messageStats");

            if (!parametersDictionary.ContainsKey("connection_details"))
                throw new DictionaryMissingArgumentException("connection_details");

            return true;
        }

    }
}
