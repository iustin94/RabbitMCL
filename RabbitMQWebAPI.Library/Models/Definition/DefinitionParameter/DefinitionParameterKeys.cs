using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter
{
    public static class DefinitionParameterKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
         "value",
         "vhost",
         "component",
         "name"   
        };
    }
}
