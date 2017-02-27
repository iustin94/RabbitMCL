using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails;
using RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection;
using RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Channel
{
    public class ChannelSentinel : Sentinel<Channel>
    {
      
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelConnectionDetailsSentinel channelConnectionDetailsSentinel = new ChannelConnectionDetailsSentinel();
            ChannelGarbageCollectionSentinel garbageCollectionSentinel = new ChannelGarbageCollectionSentinel();
            ChannelMessageStatsSentinel channelMessageStatsSentinel = new ChannelMessageStatsSentinel();

            Channel model = new Channel();

            model.vhost = parametersDictionary["vhost"].ToString();
            model.user = parametersDictionary["user"].ToString();
            model.number = Int32.Parse(parametersDictionary["number"].ToString());
            model.name = parametersDictionary["name"].ToString();
            model.node = parametersDictionary["node"].ToString();

            model.garbage_collection =(ChannelGarbageCollection.ChannelGarbageCollection)garbageCollectionSentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["garbage_collection"].ToString()), new ChannelGarbageCollection.ChannelGarbageCollection());

            model.reductions = Int32.Parse(parametersDictionary["reductions"].ToString());
            model.state = State.EvaluateState(parametersDictionary["state"].ToString());
            model.global_prefetch_count = Int32.Parse(parametersDictionary["global_prefetch_count"].ToString());
            model.prefetch_count = Int32.Parse(parametersDictionary["prefetch_count"].ToString());
            model.acks_uncommitted = Int32.Parse(parametersDictionary["acks_uncommitted"].ToString());
            model.messages_uncommitted = Int32.Parse(parametersDictionary["messages_uncommitted"].ToString());
            model.messages_unconfirmed = Int32.Parse(parametersDictionary["messages_unconfirmed"].ToString());
            model.messages_unacknowledged = Int32.Parse(parametersDictionary["messages_unacknowledged"].ToString());
            model.consumer_count = Int32.Parse(parametersDictionary["consumer_count"].ToString());
            model.confirm = Boolean.Parse(parametersDictionary["confirm"].ToString());
            model.transactional = Boolean.Parse(parametersDictionary["transactional"].ToString());
            model.idle_since = parametersDictionary["idle_since"].ToString();

            model.reduction_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["reductions_details"].ToString());

            model.message_stats = parametersDictionary.ContainsKey("message_stats")? (ChannelMessageStats.ChannelMessageStats)
                channelMessageStatsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["message_stats"].ToString()), new ChannelMessageStats.ChannelMessageStats()): null;

            model.connection_details =
                (ChannelConnectionDetails.ChannelConnectionDetails)
                channelConnectionDetailsSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["connection_details"].ToString( )), new ChannelConnectionDetails.ChannelConnectionDetails());

            return model;

        }

    }
}
