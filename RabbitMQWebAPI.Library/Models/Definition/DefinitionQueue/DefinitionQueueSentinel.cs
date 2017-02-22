using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionQueue
{
    public class DefinitionQueueSentinel : Sentinel<DefinitionQueue, DefinitionQueueParameters>
    { 
        public override DefinitionQueueParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
           DefinitionQueueParameters parameters = new DefinitionQueueParameters();
            parameters.auto_delete = Boolean.Parse(parametersDictionary["auto_delete"].ToString());
            parameters.durable = Boolean.Parse(parametersDictionary["durable"].ToString());
            parameters.name = parametersDictionary["name"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.arguments = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
