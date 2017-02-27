using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Channel;
using RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails;
using RabbitMQWebAPI.Library.Models.Connection;
using RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Consumer
{
    public class ConsumerSentinel : Sentinel<Consumer>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ConsumerChannelDetailsSentinel sentinel = new ConsumerChannelDetailsSentinel();

            Consumer model = new Consumer();
            model.arguments = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            model.prefetch_count = double.Parse(parametersDictionary["prefetch_count"].ToString());
            model.ack_required = Boolean.Parse(parametersDictionary["ack_required"].ToString());
            model.exclusive = Boolean.Parse(parametersDictionary["exclusive"].ToString());
            model.consumer_tag = parametersDictionary["consumer_tag"].ToString();

            model.queue =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["queue"].ToString());

            model.channel_details = (ConsumerChannelDetails.ConsumerChannelDetails)sentinel.CreateModel(
                JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["channel_details"].ToString()), new ConsumerChannelDetails.ConsumerChannelDetails());

            return model;
        }

       
    }
}
