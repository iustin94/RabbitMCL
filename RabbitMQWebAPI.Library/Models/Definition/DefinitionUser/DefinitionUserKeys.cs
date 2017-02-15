using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionUser
{
    public static class DefinitionUserKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
        {
            "name",
            "password_hash",
            "hashing_algorithm",
            "tags"
        };
    }
}
