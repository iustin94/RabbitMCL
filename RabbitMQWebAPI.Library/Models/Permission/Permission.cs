using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Permission
{
    public class Permission: Model
    {
        public string user { get; internal set; }
        public string vhost { get; internal set; }
        public string configure { get; internal set; }
        public string write { get; internal set; }
        public string read { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "user",
            "vhost",
            "configure",
            "write",
            "read"
        };
            }

            set { Keys = value; }
        }

        public Permission() { }
    }
}
