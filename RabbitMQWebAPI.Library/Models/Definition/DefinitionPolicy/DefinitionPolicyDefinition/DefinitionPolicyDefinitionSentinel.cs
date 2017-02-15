using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy.DefinitionPolicyDefinition
{
    public class DefinitionPolicyDefinitionSentinel : Sentinel<DefinitionPolicyDefinition, DefinitionPolicyDefinitionParameters>
    {
        public override DefinitionPolicyDefinitionParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionPolicyDefinitionParameters parameters = new DefinitionPolicyDefinitionParameters();
            parameters.ha_mode = parametersDictionary["ha-mode"].ToString();
            parameters.ha_sync_mode = parametersDictionary["ha-sync-mode"].ToString();
            parameters.ha_sync_batch_size = Int32.Parse(parametersDictionary["ha-sync-batch-size"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionPolicyDefinitionKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw  new DictionaryMissingArgumentException(key);
            }
            return true;
        }
    }
}
