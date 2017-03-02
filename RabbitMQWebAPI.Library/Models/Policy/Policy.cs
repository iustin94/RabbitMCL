using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Policy
{
    public class Policy: Model
    {
        public string vhost { get; internal set; }
        public string name { get; internal set; }
        public string pattern { get; internal set; }
        public string apply_to { get; internal set; }
        public PolicyDefinition.PolicyDefinition definition { get; internal set; }
        public double priority { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
                {
                    "vhost",
                    "name",
                    "pattern",
                    "apply-to",
                    "definition",
                    "priority"
                };
            }

            set { Keys = value; }
        }

        public Policy() { }
    }
}
