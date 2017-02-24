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
    public class ExtentionInfoSentinel : Sentinel<ExtentionInfo>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ExtentionInfo parameters = new ExtentionInfo();
            parameters.javascript = parametersDictionary["javascript"].ToString();

            return parameters;
        }
    }
}
