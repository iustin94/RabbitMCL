using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueGarbageCollection
{
    public class QueueGarbageCollection : Model
    {



        [JsonProperty(PropertyName = "max_heap_size")]
        public double max_heap_size { get; private set; }

        [JsonProperty(PropertyName = "min_bin_heap_size")]
        public double min_bin_vheap_size { get; private set; }

        [JsonProperty(PropertyName = "min_heap_size")]
        public double min_heap_size { get; private set; }

        [JsonProperty(PropertyName = "fullsweep_after")]
        public double fullsweep_after { get; private set; }

        [JsonProperty(PropertyName = "minor_gcs")]
        public double minor_gcs { get; private set; }

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
