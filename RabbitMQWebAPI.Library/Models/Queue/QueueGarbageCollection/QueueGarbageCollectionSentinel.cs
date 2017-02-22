using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueGarbageCollection
{
    public class QueueGarbageCollectionSentinel : Sentinel<QueueGarbageCollection, QueueGarbageCollectionParameters>
    {
        public override QueueGarbageCollectionParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            QueueGarbageCollectionParameters parameters = new QueueGarbageCollectionParameters();

            parameters.max_heap_size = Int32.Parse(parametersDictionary["max_heap_size"].ToString());
            parameters.min_bin_vheap_size = Int32.Parse(parametersDictionary["min_bin_vheap_size"].ToString());
            parameters.min_heap_size = Int32.Parse(parametersDictionary["min_heap_size"].ToString());
            parameters.fullsweep_after = Int32.Parse(parametersDictionary["fullsweep_after"].ToString());
            parameters.minor_gcs = Int32.Parse(parametersDictionary["minor_gcs"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in QueueGarbageCollectionKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
