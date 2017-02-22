using System;
using System.Collections.Generic;

namespace RabbitMQWebAPI.Library.Models.Sentinel
{
    public interface ISentinel<T,U>
    {
        T CreateModel(IDictionary<string, object> parametersDictionary);

        U ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary);

        Boolean ValidateDictionary(IDictionary<string, object> parametersDictionary);
    }
}
