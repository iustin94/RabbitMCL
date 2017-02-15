using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection
{
    public struct ChannelGarbageCollectionParameters
    {
        public int max_heap_size;
        public int min_bin_heap_size;
        public int min_heap_size;
        public int fullsweep_after;
        public int minor_gcs;

    }
}
