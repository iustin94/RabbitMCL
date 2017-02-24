using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelGarbageCollection
{
    public class ChannelGarbageCollection: Model
    {
        [JsonProperty(PropertyName = "max_heap_size")]
        public int max_heap_size { get; internal set; }

        [JsonProperty(PropertyName = "min_bin_vheap_size")]
        public int min_bin_vheap_size { get; internal set; }

        [JsonProperty(PropertyName = "min_heap_size")]
        public int min_heap_size { get; internal set; }

        [JsonProperty(PropertyName = "fullsweep_after")]
        public int fullsweep_after { get; internal set;}

        [JsonProperty(PropertyName = "minor_gcs")]
        public int minor_gcs { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "max_heap_size",
            "min_bin_vheap_size",
            "min_heap_size",
            "fullsweep_after",
            "minor_gcs"
        };
            }

            set { Keys = value; }
        }

        public ChannelGarbageCollection() { }

    }
}
