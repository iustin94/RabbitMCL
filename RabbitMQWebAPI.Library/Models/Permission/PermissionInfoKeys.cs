using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Permission
{
    public static class PermissionInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "user",
            "vhost",
            "configure",
            "write",
            "read"
        };
    }
}
