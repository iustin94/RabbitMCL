using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition
{
    public class DefinitionSentinel : Sentinel<Definition>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            Definition parameters = new Definition();
            parameters.rabbit_version = parametersDictionary["rabbit_version"].ToString();

            List<DefinitionUser.DefinitionUser> usersList =
                JsonConvert.DeserializeObject<List<DefinitionUser.DefinitionUser>>(
                    parametersDictionary["users"].ToString());
            parameters.users = usersList;

            parameters.vhosts = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(parametersDictionary["vhosts"].ToString());

            List<DefinitionPermission.DefinitionPermission> permissionsList = 
                JsonConvert.DeserializeObject<List<DefinitionPermission.DefinitionPermission>>(
                    parametersDictionary["permissions"].ToString());
            parameters.permissions = permissionsList;

            List<DefinitionParameter.DefinitionParameter> parametersList =
                JsonConvert.DeserializeObject<List<DefinitionParameter.DefinitionParameter>>(
                    parametersDictionary["parameters"].ToString());
            parameters.parameters = parametersList;

            List<DefinitionPolicy.DefinitionPolicy> policiesList =
                JsonConvert.DeserializeObject<List<DefinitionPolicy.DefinitionPolicy>>(
                    parametersDictionary["policies"].ToString());
            parameters.policies = policiesList;

            List<DefinitionQueue.DefinitionQueue> queuesList =
                JsonConvert.DeserializeObject<List<DefinitionQueue.DefinitionQueue>>(
                    parametersDictionary["queues"].ToString());
            parameters.queues = queuesList;

            List<DefinitionExchange.DefinitionExchange> exchangeList =
                JsonConvert.DeserializeObject<List<DefinitionExchange.DefinitionExchange>>(
                    parametersDictionary["exchanges"].ToString());
            parameters.exchanges = exchangeList;

            List<DefinitionBinding.DefinitionBinding> bindingList =
                JsonConvert.DeserializeObject<List<DefinitionBinding.DefinitionBinding>>(
                    parametersDictionary["bindings"].ToString());
            parameters.bindings = bindingList;

            return parameters;
        }
    }
}
