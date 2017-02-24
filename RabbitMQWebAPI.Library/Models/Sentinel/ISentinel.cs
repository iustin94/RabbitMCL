using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Sentinel
{
    public interface ISentinel 
    {
        IModel CreateModel(IDictionary<string, object> parametersDictionary, IModel model);

        IModel ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary);

        Boolean ValidateDictionary(IDictionary<string, object> parametersDictionary, IModel model);
    }
}
