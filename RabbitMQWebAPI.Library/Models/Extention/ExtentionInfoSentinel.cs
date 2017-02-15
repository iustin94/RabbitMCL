using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Exchange;

namespace RabbitMQWebAPI.Library.Models.Extention
{
    public class ExtentionInfoSentinel : Sentinel<ExtentionInfo, ExtentionInfoParameters>
    {
        public override ExtentionInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ExtentionInfoParameters parameters = new ExtentionInfoParameters();
            parameters.javascript = parametersDictionary["javascript"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ExtentionInfoKeys.keys)
            {
                if (!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
