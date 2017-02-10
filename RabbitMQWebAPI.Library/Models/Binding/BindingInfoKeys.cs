using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Binding
{
    public static class BindingInfoKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        { "source",
            "vhost",
            "destination",
            "destination_type",
            "routing_key",
            "arguments",
            "properties_key" };
    }
}
