using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.DataAccess;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Channel.MessageStats
{
    class MessageStatsSentinel : IParameterSentinel<MessageStats, MessageStatsParameters>
    {
        public MessageStats CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            MessageStats toReturn;

            if (ValidateDictionary(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new MessageStats(ParseDictionaryToParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        //God, don't look here pls
        public MessageStatsParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            MessageStatsParameters parameters = new MessageStatsParameters();

           

            parameters.publish_in = Int32.Parse(parametersDictionary["publish_int"].ToString());
            parameters.publish_in_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["publish_in_details"].ToString());

            parameters.publish = Int32.Parse(parametersDictionary["publish"].ToString());
            parameters.publish_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["publish_details"].ToString());

            parameters.publish_out = Int32.Parse(parametersDictionary["publish_out"].ToString());
            parameters.publish_out_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["publish_out_datails"].ToString());

            parameters.ack = Int32.Parse(parametersDictionary["ack"].ToString());
            parameters.ack_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["ack_details"].ToString());

            parameters.deliver_get = Int32.Parse(parametersDictionary["deliver_get"].ToString());
            parameters.deliver_get_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["deliver_get_details"].ToString());

            parameters.confirm = Int32.Parse(parametersDictionary["confirm"].ToString());
            parameters.confirm_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["confirm_details"].ToString());

            parameters.return_unroutable = Int32.Parse(parametersDictionary["return_unroutable"].ToString());
            parameters.return_unroutable_details = JsonConvert.DeserializeObject<
                                                   Dictionary<string, int>>(
                                                       parametersDictionary["return_unroutable_details"].ToString());

            parameters.redeliver = Int32.Parse(parametersDictionary["redeliver"].ToString());
            parameters.redeliver_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["redeliver_details"].ToString());

            parameters.deliver = Int32.Parse(parametersDictionary["deliver"].ToString());
            parameters.deliver_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["deliver_details"].ToString());


            parameters.deliver_no_ack = Int32.Parse(parametersDictionary["deliver_no_ack"].ToString());
            parameters.deliver_no_ack_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["deliver_no_ack_details"].ToString());

            parameters.get = Int32.Parse(parametersDictionary["get"].ToString());
            parameters.get_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["get_details"].ToString());

            parameters.get_no_ack = Int32.Parse(parametersDictionary["get_no_ack"].ToString());
            parameters.get_no_ack_details = JsonConvert.DeserializeObject<Dictionary<string, int>>(parametersDictionary["get_no_ack_details"].ToString());

            return parameters;

        }

        //God, don't look here pls
        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            if (!parametersDictionary.ContainsKey("publish"))
                throw new DictionaryMissingArgumentException("publish");
            if (!parametersDictionary.ContainsKey("publish_details"))
                throw new DictionaryMissingArgumentException("publish_details");

            if (!parametersDictionary.ContainsKey("publish_in"))
                throw new DictionaryMissingArgumentException("publish_in");
            if (!parametersDictionary.ContainsKey("publish_in_details"))
                throw new DictionaryMissingArgumentException("publish_in_details");

            if (!parametersDictionary.ContainsKey("publish_out"))
                throw new DictionaryMissingArgumentException("publish_out");
            if (!parametersDictionary.ContainsKey("publish_out_details"))
                throw new DictionaryMissingArgumentException("publish_out_details");

            if (!parametersDictionary.ContainsKey("ack"))
                throw new DictionaryMissingArgumentException("ack");
            if (!parametersDictionary.ContainsKey("ack_details"))
                throw new DictionaryMissingArgumentException("ack_details");

            if (!parametersDictionary.ContainsKey("deliver_get"))
                throw new DictionaryMissingArgumentException("deliver_get");
            if (!parametersDictionary.ContainsKey("deliver_get_details"))
                throw new DictionaryMissingArgumentException("deliver_get_details");

            if (!parametersDictionary.ContainsKey("confirm"))
                throw new DictionaryMissingArgumentException("confirm");
            if (!parametersDictionary.ContainsKey("confirm_details"))
                throw new DictionaryMissingArgumentException("confirm_details");

            if (!parametersDictionary.ContainsKey("return_unroutable"))
                throw new DictionaryMissingArgumentException("return_unroutable");
            if (!parametersDictionary.ContainsKey("return_unroutable_details"))
                throw new DictionaryMissingArgumentException("return_unroutable_details");

            if (!parametersDictionary.ContainsKey("redeliver"))
                throw new DictionaryMissingArgumentException("redeliver");
            if (!parametersDictionary.ContainsKey("redeliver_details"))
                throw new DictionaryMissingArgumentException("redeliver_details");

            if (!parametersDictionary.ContainsKey("deliver"))
                throw new DictionaryMissingArgumentException("deliver");
            if (!parametersDictionary.ContainsKey("deliver_details"))
                throw new DictionaryMissingArgumentException("deliver_details");

            if (!parametersDictionary.ContainsKey("deliver_no_ack"))
                throw new DictionaryMissingArgumentException("deliver_no_ack");
            if (!parametersDictionary.ContainsKey("deliver_no_ack_details"))
                throw new DictionaryMissingArgumentException("deliver_no_ack_details");

            if (!parametersDictionary.ContainsKey("get"))
                throw new DictionaryMissingArgumentException("get");
            if (!parametersDictionary.ContainsKey("get_details"))
                throw new DictionaryMissingArgumentException("get_details");

            if (!parametersDictionary.ContainsKey("get_no_ack"))
                throw new DictionaryMissingArgumentException("get_no_ack");
            if (!parametersDictionary.ContainsKey("get_no_ack_details"))
                throw new DictionaryMissingArgumentException("get_no_ack_details");

            return true;
        }
    }
}
