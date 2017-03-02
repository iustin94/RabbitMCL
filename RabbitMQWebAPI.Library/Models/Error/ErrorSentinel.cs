using RabbitMQWebAPI.Library.Models.Sentinel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Error
{
    public class ErrorSentinel : Sentinel<Error>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            Error model = new Error();
            model.error = parametersDictionary["error"].ToString();
            model.reason = parametersDictionary["reason"].ToString();

            return model;
        }
    }
}
