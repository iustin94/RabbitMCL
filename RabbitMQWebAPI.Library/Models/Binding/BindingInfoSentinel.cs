using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebApi.Library.Models.Binding;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Binding
{
    /// <summary>
    /// Class that inspects parameters before creating a BindingInfo. This prevents creation of invalid objects. Use this to create the BindingInfo object then store that object.
    /// </summary>
    public class BindingInfoSentinel: Sentinel<BindingInfo, BindingInfoParameters>
    {
        public override bool ValidateDictionary(
            IDictionary<string, object> parametersDictionary)
        {
            foreach (string key in BindingInfoKeys.keys)
            {
                if (!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }

        public override BindingInfoParameters ParseDictionaryToParameters(
            IDictionary<string, object> parametersDictionary)
        {

            BindingInfoParameters parameters = new BindingInfoParameters();
            parameters.source = parametersDictionary["source"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.arguments = JsonConvert.DeserializeObject<
                                   Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            parameters.destination = parametersDictionary["destination"].ToString();
            parameters.destination_type = parametersDictionary["destination_type"].ToString();
            parameters.properties_key = parametersDictionary["properties_key"].ToString();
            parameters.routing_key = parametersDictionary["routing_key"].ToString();

            return parameters;
        }

       
    }
}
