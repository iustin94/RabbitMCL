using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionQueue
{
    public static class DefinitionQueueKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "vhost",
            "durable",
            "auto_delete",
            "arguments"
        };
    }
}
