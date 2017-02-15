using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueGarbageCollection
{
    public class QueueGarbageCollection
    {
        public int max_heap_size { get; private set; }
        public int min_bin_vheap_size { get; private set; }
        public int min_heap_size { get; private set; }
        public int fullsweep_after { get; private set; }
        public int minor_gcs { get; private set; }

        public QueueGarbageCollection() { }

        public QueueGarbageCollection(QueueGarbageCollectionParameters parameters)
        {
            this.max_heap_size = parameters.max_heap_size;
            this.min_bin_vheap_size = parameters.min_bin_vheap_size;
            this.max_heap_size = parameters.min_heap_size;
            this.fullsweep_after = parameters.fullsweep_after;
            this.minor_gcs = parameters.minor_gcs;
        }
    }
}
