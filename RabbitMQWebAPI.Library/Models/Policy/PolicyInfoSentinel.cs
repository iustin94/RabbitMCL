using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Policy
{
    public class PolicyInfoSentinel : Sentinel<PolicyInfo, PolicyInfoParameters>
    {
        public override PolicyInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            PolicyDefinitionSentinel policyDefinitionSentinel = new PolicyDefinitionSentinel();

            PolicyInfoParameters parameters = new PolicyInfoParameters();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.pattern = parametersDictionary["pattern"].ToString();
            parameters.apply_to = parametersDictionary["apply_to"].ToString();
            parameters.definition =
                policyDefinitionSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["definition"].ToString()));
            parameters.priority = Int32.Parse(parametersDictionary["priority"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in PolicyInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
