using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition
{
    public class PolicyDefinitionSentinel : Sentinel<PolicyDefinition, PolicyDefinitionParameters>
    {
        public override PolicyDefinitionParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            PolicyDefinitionParameters parameters = new PolicyDefinitionParameters();
            parameters.ha_mode = parametersDictionary["ha-mode"].ToString();
            parameters.ha_sync_batch_size = parametersDictionary["ha-sync-batch-size"].ToString();
            parameters.ha_sync_mode = parametersDictionary["ha-sync-mode"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in PolicyDefinitionKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
