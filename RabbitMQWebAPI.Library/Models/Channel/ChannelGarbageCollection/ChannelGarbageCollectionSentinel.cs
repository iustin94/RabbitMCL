using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection
{
    class ChannelGarbageCollectionSentinel : Sentinel<ChannelGarbageCollection, ChannelGarbageCollectionParameters>
    {


        public override ChannelGarbageCollectionParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelGarbageCollectionParameters parameters = new ChannelGarbageCollectionParameters();
            parameters.fullsweep_after = Int32.Parse(parametersDictionary["fullsweep_after"].ToString());
            parameters.max_heap_size = Int32.Parse(parametersDictionary["max_heap_size"].ToString());
            parameters.min_bin_heap_size = Int32.Parse(parametersDictionary["min_bin_heap_size"].ToString());
            parameters.min_heap_size = Int32.Parse(parametersDictionary["min_heap_size"].ToString());
            parameters.minor_gcs = Int32.Parse(parametersDictionary["minor_gcs"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ChannelGarbageCollectionKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
