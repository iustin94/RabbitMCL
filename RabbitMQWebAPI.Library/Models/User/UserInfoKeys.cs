using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.User
{
    public static class UserInfoKeys
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
