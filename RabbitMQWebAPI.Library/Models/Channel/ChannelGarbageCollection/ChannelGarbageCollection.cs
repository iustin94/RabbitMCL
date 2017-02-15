using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection
{
    public class ChannelGarbageCollection
    {
        public int max_heap_size { get; private set; }
        public int min_bin_vheap_size { get; private set; }
        public int min_heap_size { get; private set; }
        public int fullsweep_after { get; private set;}
        public int minor_gcs { get; private set; }

        public ChannelGarbageCollection() { }
        public ChannelGarbageCollection(ChannelGarbageCollectionParameters parameters)
        {
            this.fullsweep_after = parameters.fullsweep_after;
            this.max_heap_size = parameters.fullsweep_after;
            this.min_bin_vheap_size = parameters.min_bin_heap_size;
            this.min_heap_size = parameters.min_heap_size;
            this.minor_gcs = parameters.minor_gcs;
        }

    }
}
