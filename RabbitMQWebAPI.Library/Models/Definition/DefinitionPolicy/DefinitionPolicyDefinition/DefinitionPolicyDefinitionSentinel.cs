using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy.DefinitionPolicyDefinition
{
    public class DefinitionPolicyDefinitionSentinel : Sentinel<DefinitionPolicyDefinition>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionPolicyDefinition parameters = new DefinitionPolicyDefinition();
            parameters.ha_mode = parametersDictionary["ha-mode"].ToString();
            parameters.ha_sync_mode = parametersDictionary["ha-sync-mode"].ToString();
            parameters.ha_sync_batch_size = Int32.Parse(parametersDictionary["ha-sync-batch-size"].ToString());

            return parameters;
        }
    }
}
