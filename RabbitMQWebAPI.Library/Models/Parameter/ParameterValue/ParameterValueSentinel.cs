using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Parameter.ParameterValue
{
    public class ParameterValueSentinel : Sentinel<ParameterValue, ParameterValueParameters>
    {
        public override ParameterValueParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ParameterValueParameters parameters = new ParameterValueParameters();
            parameters.src_queue = parametersDictionary["src-queue"].ToString();
            parameters.src_uri = parametersDictionary["src-uri"].ToString();
            parameters.dest_uri = parametersDictionary["dest-uri"].ToString();
            parameters.dest_queue = parametersDictionary["dest-queue"].ToString();
            parameters.prefetch_count = Int32.Parse(parametersDictionary["prefetch-count"].ToString());
            parameters.reconnect_delay = Int32.Parse(parametersDictionary["reconnect_delay"].ToString());
            parameters.add_forward_headers = Boolean.Parse(parametersDictionary["add-forward-headers"].ToString());
            parameters.ack_mode = parametersDictionary["ack-mode"].ToString();
            parameters.delete_after = parametersDictionary["delete-after"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ParameterValueKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
