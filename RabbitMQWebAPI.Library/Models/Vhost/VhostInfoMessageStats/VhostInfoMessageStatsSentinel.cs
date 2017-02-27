using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Vhost.VhostInfoMessageStats
{
    public class VhostInfoMessageStatsSentinel : Sentinel<VhostInfoMessageStats>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            VhostInfoMessageStats model = new VhostInfoMessageStats();

            model.publish_in = double.Parse(parametersDictionary["publish_int"].ToString());
            model.publish_in_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["publish_in_details"].ToString());

            model.publish = double.Parse(parametersDictionary["publish"].ToString());
            model.publish_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["publish_details"].ToString());

            model.publish_out = double.Parse(parametersDictionary["publish_out"].ToString());
            model.publish_out_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["publish_out_datails"].ToString());

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

            model.deliver = double.Parse(parametersDictionary["deliver"].ToString());
            model.deliver_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["deliver_details"].ToString());


            model.deliver_no_ack = double.Parse(parametersDictionary["deliver_no_ack"].ToString());
            model.deliver_no_ack_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["deliver_no_ack_details"].ToString());

            model.get = double.Parse(parametersDictionary["get"].ToString());
            model.get_details = JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["get_details"].ToString());

            model.get_no_ack = double.Parse(parametersDictionary["get_no_ack"].ToString());
            model.get_no_ack_details = JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["get_no_ack_details"].ToString());

            return model;
        }
    }
}
