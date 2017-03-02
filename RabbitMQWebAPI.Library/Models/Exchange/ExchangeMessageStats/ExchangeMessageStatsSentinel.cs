using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Exchange.ExchangeMessageStats
{
    class ExchangeMessageStatsSentinel : Sentinel<ExchangeMessageStats>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
           ExchangeMessageStats parameters = new ExchangeMessageStats();
            parameters.publish_in = double.Parse(parametersDictionary["publish_in"].ToString());
            parameters.publish_in_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["publish_in_details"].ToString());

            parameters.publish = double.Parse(parametersDictionary["publish"].ToString());
            parameters.publish_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["publish_details"].ToString());

            parameters.publish_out = double.Parse(parametersDictionary["publish_out"].ToString());
            parameters.publish_out_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["publish_out_details"].ToString());

            parameters.ack = double.Parse(parametersDictionary["ack"].ToString());
            parameters.ack_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["ack_details"].ToString());

            parameters.deliver_get = double.Parse(parametersDictionary["deliver_get"].ToString());
            parameters.deliver_get_details = JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["deliver_get_details"].ToString());

            parameters.confirm = double.Parse(parametersDictionary["confirm"].ToString());
            parameters.confirm_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["confirm_details"].ToString());

            parameters.return_unroutable = double.Parse(parametersDictionary["return_unroutable"].ToString());
            parameters.return_unroutable_details = JsonConvert.DeserializeObject<
                                                   Dictionary<string, double>>(
                                                       parametersDictionary["return_unroutable_details"].ToString());

            parameters.redeliver = double.Parse(parametersDictionary["redeliver"].ToString());
            parameters.redeliver_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["redeliver_details"].ToString());

            return parameters;
        }
    }
}
