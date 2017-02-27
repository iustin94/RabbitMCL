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
        public double max_heap_size { get; internal set; }

        [JsonProperty(PropertyName = "min_bin_vheap_size")]
        public double min_bin_vheap_size { get; internal set; }

        [JsonProperty(PropertyName = "min_heap_size")]
        public double min_heap_size { get; internal set; }

        [JsonProperty(PropertyName = "fullsweep_after")]
        public double fullsweep_after { get; internal set;}

        [JsonProperty(PropertyName = "minor_gcs")]
        public double minor_gcs { get; internal set; }

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
