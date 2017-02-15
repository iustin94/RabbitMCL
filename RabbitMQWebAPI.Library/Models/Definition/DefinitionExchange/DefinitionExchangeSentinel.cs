using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionExchange
{
    public class DefinitionExchangeSentinel : Sentinel<DefinitionExchange, DefinitionExchangeParameters>
    {
        public override DefinitionExchangeParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionExchangeParameters parameters = new DefinitionExchangeParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.type = parametersDictionary["type"].ToString();
            parameters.durable = Boolean.Parse(parametersDictionary["durable"].ToString());
            parameters.auto_delete = Boolean.Parse(parametersDictionary["auto-delete"].ToString());
            parameters._internal = Boolean.Parse(parametersDictionary["internal"].ToString());
            parameters.arguments =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            
            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionExchangeKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
