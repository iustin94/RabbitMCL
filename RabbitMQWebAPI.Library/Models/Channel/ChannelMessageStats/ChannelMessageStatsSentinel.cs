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

            model.publish_in = Int32.Parse(parametersDictionary["publish_int"].ToString());
            model.publish_in_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["publish_in_details"].ToString());

            model.publish = Int32.Parse(parametersDictionary["publish"].ToString());
            model.publish_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["publish_details"].ToString());

            model.publish_out = Int32.Parse(parametersDictionary["publish_out"].ToString());
            model.publish_out_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["publish_out_datails"].ToString());

            model.ack = Int32.Parse(parametersDictionary["ack"].ToString());
            model.ack_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["ack_details"].ToString());

            model.deliver_get = Int32.Parse(parametersDictionary["deliver_get"].ToString());
            model.deliver_get_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["deliver_get_details"].ToString());

            model.confirm = Int32.Parse(parametersDictionary["confirm"].ToString());
            model.confirm_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["confirm_details"].ToString());

            model.return_unroutable = Int32.Parse(parametersDictionary["return_unroutable"].ToString());
            model.return_unroutable_details = JsonConvert.DeserializeObject<
                                                   Dictionary<string, int>>(
                                                       parametersDictionary["return_unroutable_details"].ToString());

            model.redeliver = Int32.Parse(parametersDictionary["redeliver"].ToString());
            model.redeliver_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["redeliver_details"].ToString());

            model.deliver = Int32.Parse(parametersDictionary["deliver"].ToString());
            model.deliver_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["deliver_details"].ToString());


            model.deliver_no_ack = Int32.Parse(parametersDictionary["deliver_no_ack"].ToString());
            model.deliver_no_ack_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["deliver_no_ack_details"].ToString());

            model.get = Int32.Parse(parametersDictionary["get"].ToString());
            model.get_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["get_details"].ToString());

            model.get_no_ack = Int32.Parse(parametersDictionary["get_no_ack"].ToString());
            model.get_no_ack_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["get_no_ack_details"].ToString());

            return model;
        }   
       
    }
}
