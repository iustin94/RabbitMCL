using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter.DefinitionParameterValue
{
    public static class DefinitionParameterValueKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "src-uri",
            "src-queue",
            "dest-uri",
            "dest-queue",
            "prefetch-count",
            "reconnect-delay",
            "add-forward-headers",
            "ack-mode",
            "delete-after"
        };
    }
}
