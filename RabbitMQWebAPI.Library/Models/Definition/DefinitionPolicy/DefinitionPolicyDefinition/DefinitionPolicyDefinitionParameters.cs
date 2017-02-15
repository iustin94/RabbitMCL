using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPolicy.DefinitionPolicyDefinition
{
    public struct DefinitionPolicyDefinitionParameters
    {
        public string ha_mode;
        public string ha_sync_mode;
        public int ha_sync_batch_size;
    }
}
