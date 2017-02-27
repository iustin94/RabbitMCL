using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition
{
    public class PolicyDefinitionSentinel : Sentinel<PolicyDefinition>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            PolicyDefinition parameters = new PolicyDefinition();
            parameters.ha_mode = parametersDictionary["ha-mode"].ToString();
            parameters.ha_sync_batch_size = parametersDictionary["ha-sync-batch-size"].ToString();
            parameters.ha_sync_mode = parametersDictionary["ha-sync-mode"].ToString();

            return parameters;
        }
    }
}
