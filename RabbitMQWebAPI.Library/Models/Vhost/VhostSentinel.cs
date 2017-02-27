using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;
using RabbitMQWebAPI.Library.Models.Vhost.VhostInfoMessageStats;

namespace RabbitMQWebAPI.Library.Models.Vhost
{
    public class VhostSentinel : Sentinel<Vhost>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            VhostInfoMessageStatsSentinel sentinel = new VhostInfoMessageStatsSentinel();

            Vhost model = new Vhost();

            VhostInfoMessageStats.VhostInfoMessageStats messageStats = parametersDictionary.ContainsKey("message_stats")? (VhostInfoMessageStats.VhostInfoMessageStats)
                sentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["message_stats"].ToString()), new VhostInfoMessageStats.VhostInfoMessageStats()): null;

            model.message_stats = messageStats;
            model.send_oct = double.Parse(parametersDictionary["send_oct"].ToString());
            model.send_oct_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(parametersDictionary["send_oct_details"].ToString());

            model.recv_oct = double.Parse(parametersDictionary["recv_oct"].ToString());
            model.recv_oct_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["recv_oct_details"].ToString());

            model.messages = double.Parse(parametersDictionary["messages"].ToString());
            model.messages_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["message_details"].ToString());

            model.messages_ready = double.Parse(parametersDictionary["messages_ready"].ToString());
            model.messages_ready_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["messages_ready_details"].ToString());

            model.messages_unacknowledged = double.Parse(parametersDictionary["messages_unacknowledged"].ToString());
            model.messages_unacknowledged_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["messages_unacknowledged_details"].ToString());

            model.name = parametersDictionary["name"].ToString();
            model.tracing = Boolean.Parse(parametersDictionary["tracing"].ToString());

            return model;
        }
    }
}
