using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models
{
    public interface ISentinel<T,U>
    {
        T CreateModel(IDictionary<string, object> parametersDictionary);

        U ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary);

        Boolean ValidateDictionary(IDictionary<string, object> parametersDictionary);
    }
}
