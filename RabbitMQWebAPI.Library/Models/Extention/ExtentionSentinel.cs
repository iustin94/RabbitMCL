using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Exchange;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Extention
{
    public class ExtentionSentinel : Sentinel<Extention>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            Extention parameters = new Extention();
            parameters.javascript = parametersDictionary["javascript"].ToString();

            return parameters;
        }
    }
}
