using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy.DefinitionPolicyDefinition
{
    public class DefinitionPolicyDefinition: Model
    {

        [JsonProperty(PropertyName = "ha-mode")]
        public string ha_mode { get; internal set; }

        [JsonProperty(PropertyName = "ha-sync-mode")]
        public string ha_sync_mode { get; internal set; }

        [JsonProperty(PropertyName = "ha-sync-batch-size")]
        public int ha_sync_batch_size { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "ha-mode",
            "ha-sync-mode",
            "ha-sync-batch-size"
        };
            }

            set { Keys = value; }
        }

        public DefinitionPolicyDefinition() { }
    }
}
