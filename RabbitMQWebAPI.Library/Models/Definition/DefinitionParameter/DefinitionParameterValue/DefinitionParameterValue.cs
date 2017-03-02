using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter.DefinitionParameterValue
{
    public class DefinitionParameterValue: Model
    {
        [JsonProperty(PropertyName = "src-uri")]
        public string src_uri { get; internal set; }

        [JsonProperty(PropertyName = "src-queue")]
        public string src_queue { get; internal set; }

        [JsonProperty(PropertyName = "dest-uri")]
        public string dest_uri { get; internal set; }

        [JsonProperty(PropertyName = "dest-queue")]
        public string dest_queue { get; internal set; }

        [JsonProperty(PropertyName = "prefetch-count")]
        public double prefetch_count { get; internal set; }

        [JsonProperty(PropertyName = "reconnect-delay")]
        public double reconnect_delay { get; internal set; }

        [JsonProperty(PropertyName = "add-forward-headers")]
        public bool add_forward_headers { get; internal set; }

        [JsonProperty(PropertyName = "ack-mode")]
        public string ack_mode { get; internal set; }

        [JsonProperty(PropertyName = "delete-after")]
        public string delete_after { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "src-uri",
            "src-queue",
            "dest-uri",
            "dest-queue",
            "prefetch-count",
            "reconnect-delay",
            "add-forward-headers",
            "ack-mode",
            "delete-after"
        };
            }

            set { Keys = value; }
        }

        public DefinitionParameterValue() { }
    
    }
}
