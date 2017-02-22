using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection
{
    public class ChannelGarbageCollection
    {
        [JsonProperty(PropertyName = "max_heap_size")]
        public int max_heap_size { get; private set; }

        [JsonProperty(PropertyName = "min_bin_vheap_size")]
        public int min_bin_vheap_size { get; private set; }

        [JsonProperty(PropertyName = "min_heap_size")]
        public int min_heap_size { get; private set; }

        [JsonProperty(PropertyName = "fullsweep_after")]
        public int fullsweep_after { get; private set;}

        [JsonProperty(PropertyName = "minor_gcs")]
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
