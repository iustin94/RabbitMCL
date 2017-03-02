using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter.DefinitionParameterValue;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter
{
    public class DefinitionParameterSentinel : Sentinel<DefinitionParameter>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionParameterValueSentinel sentinel = new DefinitionParameterValueSentinel(); 

            DefinitionParameter parameters = new DefinitionParameter();

            parameters.value = (DefinitionParameterValue.DefinitionParameterValue)
                sentinel.CreateModel(JsonConvert.DeserializeObject<
                                     Dictionary<string, object>>(parametersDictionary["value"].ToString()), new DefinitionParameterValue.DefinitionParameterValue());

            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.component = parametersDictionary["component"].ToString();
            parameters.name = parametersDictionary["name"].ToString();

            return parameters;
        }
    }
}
