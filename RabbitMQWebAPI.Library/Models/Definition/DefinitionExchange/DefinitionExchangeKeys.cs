using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionExchange
{
    public static class DefinitionExchangeKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "vhost",
            "type",
            "durable",
            "auto_delete",
            "internal",
            "arguments"
        };
    }
}
