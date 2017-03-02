using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.DataAccess;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats
{
    public class ChannelMessageStatsSentinel : Sentinel<ChannelMessageStats>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelMessageStats model = new ChannelMessageStats();

            model.publish_in = double.Parse(parametersDictionary["publish_in"].ToString());
            model.publish_in_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["publish_in_details"].ToString());

            model.publish = double.Parse(parametersDictionary["publish"].ToString());
            model.publish_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["publish_details"].ToString());

            model.publish_out = double.Parse(parametersDictionary["publish_out"].ToString());
            model.publish_out_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["publish_out_details"].ToString());

            model.ack = double.Parse(parametersDictionary["ack"].ToString());
            model.ack_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["ack_details"].ToString());

            model.deliver_get = double.Parse(parametersDictionary["deliver_get"].ToString());
            model.deliver_get_details = JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["deliver_get_details"].ToString());

            model.confirm = double.Parse(parametersDictionary["confirm"].ToString());
            model.confirm_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["confirm_details"].ToString());

            model.return_unroutable = double.Parse(parametersDictionary["return_unroutable"].ToString());
            model.return_unroutable_details = JsonConvert.DeserializeObject<
                                                   Dictionary<string, double>>(
                                                       parametersDictionary["return_unroutable_details"].ToString());

            model.redeliver = double.Parse(parametersDictionary["redeliver"].ToString());
            model.redeliver_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["redeliver_details"].ToString());

            return model;
        }   
       
    }
}
