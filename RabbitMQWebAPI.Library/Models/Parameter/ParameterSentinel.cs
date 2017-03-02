using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Parameter.ParameterValue;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Parameter
{
    public class ParameterSentinel : Sentinel<Parameter>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ParameterValueSentinel valueSentinel = new ParameterValueSentinel();

            Parameter parameters = new Parameter();
            parameters.value =(ParameterValue.ParameterValue)
                valueSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(parametersDictionary["value"].ToString()), new ParameterValue.ParameterValue());

            parameters.name = parametersDictionary["name"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.component = parametersDictionary["component"].ToString();

            return parameters;
        }
    }
}
