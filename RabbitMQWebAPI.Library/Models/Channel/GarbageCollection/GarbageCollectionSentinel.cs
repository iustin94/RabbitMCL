using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Channel.GarbageCollection
{
    class GarbageCollectionSentinel : IParameterSentinel<GarbageCollection, GarbageCollectionParameters>
    {
        public GarbageCollection CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            GarbageCollection toReturn;

            if (ValidateDictionary(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new GarbageCollection(ParseDictionaryToParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        public GarbageCollectionParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            GarbageCollectionParameters parameters = new GarbageCollectionParameters();
            parameters.fullsweep_after = Int32.Parse(parametersDictionary["fullsweep_after"].ToString());
            parameters.max_heap_size = Int32.Parse(parametersDictionary["max_heap_size"].ToString());
            parameters.min_bin_heap_size = Int32.Parse(parametersDictionary["min_bin_heap_size"].ToString());
            parameters.min_heap_size = Int32.Parse(parametersDictionary["min_heap_size"].ToString());
            parameters.minor_gcs = Int32.Parse(parametersDictionary["minor_gcs"].ToString());

            return parameters;
        }

        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            if(!parametersDictionary.ContainsKey("max_heap_size"))
                throw new DictionaryMissingArgumentException("max_heap_size");

            if(!parametersDictionary.ContainsKey("min_bin_vheap_size"))
                throw new DictionaryMissingArgumentException("min_bin_vheap_size");

            if(!parametersDictionary.ContainsKey("min_heap_size"))
                throw new DictionaryMissingArgumentException("min_heap_size");

            if(!parametersDictionary.ContainsKey("fullsweep_after"))
                throw new DictionaryMissingArgumentException("fullsweep_after");

            if(!parametersDictionary.ContainsKey("minor_gcs"))
                throw new DictionaryMissingArgumentException("minor_gcs");

            return true;
        }
    }
}
