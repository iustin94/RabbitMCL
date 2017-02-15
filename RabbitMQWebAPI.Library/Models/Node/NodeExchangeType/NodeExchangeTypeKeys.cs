using System.Collections.Generic;

namespace RabbitMQWebAPI.Library.Models.Node.NodeExchangeType
{
    public static class NodeExchangeTypeKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "description",
            "enabled"
        };
    }
}
