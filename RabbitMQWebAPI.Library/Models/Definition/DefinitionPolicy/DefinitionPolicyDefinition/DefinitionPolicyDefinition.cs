using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy.DefinitionPolicyDefinition
{
    public class DefinitionPolicyDefinition
    {

        [JsonProperty(PropertyName = "ha-mode")]
        public string ha_mode { get; private set; }

        [JsonProperty(PropertyName = "ha-sync-mode")]
        public string ha_sync_mode { get; private set; }

        [JsonProperty(PropertyName = "ha-sync-batch-size")]
        public int ha_sync_batch_size { get; private set; }

        public DefinitionPolicyDefinition() { }

        public DefinitionPolicyDefinition(DefinitionPolicyDefinitionParameters parameters)
        {
            this.ha_mode = parameters.ha_mode;
            this.ha_sync_mode = parameters.ha_sync_mode;
            this.ha_sync_batch_size = parameters.ha_sync_batch_size;
        }
    }
}
