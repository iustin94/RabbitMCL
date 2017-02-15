using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueGarbageCollection
{
    public struct QueueGarbageCollectionParameters
    {
        public int max_heap_size;
        public int min_bin_vheap_size;
        public int min_heap_size;
        public int fullsweep_after;
        public int minor_gcs;
    }
}
