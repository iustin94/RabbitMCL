using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.User
{
    public struct UserInfoParameters
    {
        public string name;
        public string password_hash;
        public string hashing_algorithm;
        public string tags;
    }
}
