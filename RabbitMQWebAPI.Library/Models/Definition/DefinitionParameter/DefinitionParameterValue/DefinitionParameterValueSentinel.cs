using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter.DefinitionParameterValue
{
    public class DefinitionParameterValueSentinel : Sentinel<DefinitionParameterValue, DefinitionParameterValueParameters>
    {
        public override DefinitionParameterValueParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionParameterValueParameters parameters = new DefinitionParameterValueParameters();
            parameters.src_uri = parametersDictionary["src-uri"].ToString();
            parameters.src_queue = parametersDictionary["src-queue"].ToString();
            parameters.dest_uri = parametersDictionary["dest-uri"].ToString();
            parameters.dest_queue = parametersDictionary["dest-queue"].ToString();
            parameters.prefetch_count = Int32.Parse(parametersDictionary["prefetch-count"].ToString());
            parameters.reconnect_delay = Int32.Parse(parametersDictionary["reconnect-delay"].ToString());
            parameters.add_forward_headers = Boolean.Parse(parametersDictionary["add-forward-headers"].ToString());
            parameters.ack_mode = parametersDictionary["ack-mode"].ToString();
            parameters.delete_after = parametersDictionary["delete-after"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionParameterValueKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
