using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Sentinel
{
    public interface ISentinelNew 
    {
        IModel CreateModel(IDictionary<string, object> parametersDictionary, IModel model);

        IModel ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary, IModel model);

        Boolean ValidateDictionary(IDictionary<string, object> parametersDictionary, IModel model);
    }
}
