using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter.DefinitionParameterValue;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter
{
    public class DefinitionParameterSentinel : Sentinel<DefinitionParameter, DefinitionParameterParameters>
    {
        public override DefinitionParameterParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionParameterValueSentinel sentinel = new DefinitionParameterValueSentinel(); 

            DefinitionParameterParameters parameters = new DefinitionParameterParameters();

            parameters.value =
                sentinel.CreateModel(JsonConvert.DeserializeObject<
                                     Dictionary<string, object>>(parametersDictionary["value"].ToString()));

            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.component = parametersDictionary["component"].ToString();
            parameters.name = parametersDictionary["name"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionParameterKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
