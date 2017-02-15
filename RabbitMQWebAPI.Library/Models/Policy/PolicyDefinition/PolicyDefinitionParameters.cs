using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition
{
    public struct PolicyDefinitionParameters
    {
        public string ha_mode;
        public string ha_sync_mode;
        public string ha_sync_batch_size;
    }
}
