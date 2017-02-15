using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Vhost.VhostInfoMessageStats;

namespace RabbitMQWebAPI.Library.Models.Vhost
{
    public class VhostInfoSentinel : Sentinel<VhostInfo, VhostInfoParameters>
    {
        public override VhostInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            VhostInfoMessageStatsSentinel sentinel = new VhostInfoMessageStatsSentinel();

            VhostInfoParameters parameters = new VhostInfoParameters();

            VhostInfoMessageStats.VhostInfoMessageStats messageStats =
                sentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["message_stats"].ToString()));

            parameters.message_stats = messageStats;
            parameters.send_oct = Int32.Parse(parametersDictionary["send_oct"].ToString());
            parameters.send_oct_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["send_oct_details"].ToString());

            parameters.recv_oct = Int32.Parse(parametersDictionary["recv_oct"].ToString());
            parameters.recv_oct_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["recv_oct_details"].ToString());

            parameters.messages = Int32.Parse(parametersDictionary["messages"].ToString());
            parameters.messages_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["message_details"].ToString());

            parameters.messages_ready = Int32.Parse(parametersDictionary["messages_ready"].ToString());
            parameters.messages_ready_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["messages_ready_details"].ToString());

            parameters.messages_unacknowledged = Int32.Parse(parametersDictionary["messages_unacknowledged"].ToString());
            parameters.messages_unacknowledged_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["messages_unacknowledged_details"].ToString());

            parameters.name = parametersDictionary["name"].ToString();
            parameters.tracing = Boolean.Parse(parametersDictionary["tracing"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in VhostInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
