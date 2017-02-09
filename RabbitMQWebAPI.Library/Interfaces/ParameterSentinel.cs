using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models;

namespace RabbitMQWebAPI.Library.Interfaces
{
    public interface IParameterSentinel<T, TU>
    {
        T CreateModel(IDictionary<string, object> parametersDictionary);
        bool ValidateDictionary(IDictionary<string, object> parametersDictionary);
        TU ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary);
    }
}
