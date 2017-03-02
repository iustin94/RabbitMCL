using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Policy.PolicyDefinition
{
    public class PolicyDefinition: Model
    {
        public string ha_mode { get; internal set; }
        public string ha_sync_mode { get; internal set; }
        public string ha_sync_batch_size { get; internal set; }

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

        public PolicyDefinition() { }
    }
}
