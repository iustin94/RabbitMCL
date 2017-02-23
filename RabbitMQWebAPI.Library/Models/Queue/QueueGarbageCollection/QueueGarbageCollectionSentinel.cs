using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueGarbageCollection
{
    public class QueueGarbageCollectionSentinel : SentinelNew<QueueGarbageCollection>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary, IModel model)
        {
            QueueGarbageCollection parameters = new QueueGarbageCollection();

            parameters.max_heap_size = Int32.Parse(parametersDictionary["max_heap_size"].ToString());
            parameters.min_bin_vheap_size = Int32.Parse(parametersDictionary["min_bin_vheap_size"].ToString());
            parameters.min_heap_size = Int32.Parse(parametersDictionary["min_heap_size"].ToString());
            parameters.fullsweep_after = Int32.Parse(parametersDictionary["fullsweep_after"].ToString());
            parameters.minor_gcs = Int32.Parse(parametersDictionary["minor_gcs"].ToString());

            return parameters;
        }
    }
}
