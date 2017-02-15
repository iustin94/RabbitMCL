using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Parameter
{
    public static class ParameterInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "values",
            "vhost",
            "component",
            "name"
        };
    }
}
