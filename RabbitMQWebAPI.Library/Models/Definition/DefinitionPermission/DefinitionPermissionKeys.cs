using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission
{
    public static class DefinitionPermissionKeys
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
