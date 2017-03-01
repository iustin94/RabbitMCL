using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Policy
{
    public class PolicySentinel : Sentinel<Policy>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            PolicyDefinitionSentinel policyDefinitionSentinel = new PolicyDefinitionSentinel();

            Policy model = new Policy();
            model.vhost = parametersDictionary["vhost"].ToString();
            model.name = parametersDictionary["name"].ToString();
            model.pattern = parametersDictionary["pattern"].ToString();
            model.apply_to = parametersDictionary["apply-to"].ToString();
            model.definition =(PolicyDefinition.PolicyDefinition)
                policyDefinitionSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["definition"].ToString()), new PolicyDefinition.PolicyDefinition());
            model.priority = Int32.Parse(parametersDictionary["priority"].ToString());

            return model;
        }
    }
}
