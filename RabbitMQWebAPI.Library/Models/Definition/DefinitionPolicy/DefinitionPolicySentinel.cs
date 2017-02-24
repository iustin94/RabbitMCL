using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy.DefinitionPolicyDefinition;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy
{
    public class DefinitionPolicySentinel : Sentinel<DefinitionPolicy>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionPolicyDefinitionSentinel sentinel = new DefinitionPolicyDefinitionSentinel();

            DefinitionPolicy parameters =  new DefinitionPolicy();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.pattern = parametersDictionary["pattern"].ToString();
            parameters.apply_to = parametersDictionary["apply-to"].ToString();

            parameters.definition =(DefinitionPolicyDefinition.DefinitionPolicyDefinition)
                sentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["definition"].ToString()), new DefinitionPolicyDefinition.DefinitionPolicyDefinition());

            parameters.priority = Int32.Parse(parametersDictionary["priority"].ToString());

            return parameters;
        }
    }
}
