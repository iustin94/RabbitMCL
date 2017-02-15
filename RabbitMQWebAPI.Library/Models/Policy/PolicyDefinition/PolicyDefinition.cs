using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition
{
    public class PolicyDefinition
    {
        public string ha_mode { get; private set; }
        public  string ha_sync_mode { get; private set; }
        public string ha_sync_batch_size { get; private set; }

        public PolicyDefinition() { }

        public PolicyDefinition(PolicyDefinitionParameters parameters)
        {
            this.ha_sync_mode = parameters.ha_sync_mode;
            this.ha_mode = parameters.ha_mode;
            this.ha_sync_batch_size = parameters.ha_sync_batch_size;
        }
    }
}
