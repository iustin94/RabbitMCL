using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy.DefinitionPolicyDefinition;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy
{
    public class DefinitionPolicySentinel : Sentinel<DefinitionPolicy, DefinitionPolicyParameters>
    {
        public override DefinitionPolicyParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionPolicyDefinitionSentinel sentinel = new DefinitionPolicyDefinitionSentinel();

            DefinitionPolicyParameters parameters =  new DefinitionPolicyParameters();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.pattern = parametersDictionary["pattern"].ToString();
            parameters.apply_to = parametersDictionary["apply-to"].ToString();

            parameters.definition =
                sentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["definition"].ToString()));

            parameters.priority = Int32.Parse(parametersDictionary["priority"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionPolicyKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
