using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Parameter.ParameterValue;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Parameter
{
    public class ParameterInfoSentinel : Sentinel<ParameterInfo, ParameterInfoParameters>
    {
        public override ParameterInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ParameterValueSentinel valueSentinel = new ParameterValueSentinel();

            ParameterInfoParameters parameters = new ParameterInfoParameters();
            parameters.value =
                valueSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["value"].ToString()));

            parameters.name = parametersDictionary["name"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.component = parametersDictionary["component"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ParameterInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
