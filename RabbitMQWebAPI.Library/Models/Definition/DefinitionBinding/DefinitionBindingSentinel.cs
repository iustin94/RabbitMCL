using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionBinding
{
    public class DefinitionBindingSentinel : Sentinel<DefinitionBinding, DefinitionBindingParameters>
    {
        public override DefinitionBindingParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionBindingParameters parameters = new DefinitionBindingParameters();;
            parameters.name = parametersDictionary["name"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.type = parametersDictionary["type"].ToString();
            parameters.durable = Boolean.Parse(parametersDictionary["durable"].ToString());
            parameters.auto_delate = Boolean.Parse(parametersDictionary["auto_delete"].ToString());
            parameters._internal = Boolean.Parse(parametersDictionary["internal"].ToString());
            parameters.arguments =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionBindingKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
