using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.User
{
    public class UserInfo
    {
        public string name { get; private set; }
        public string password_hash { get; private set;}
        public string hashing_algorithm { get; private set; }
        public string tags { get; private set; }

        public UserInfo() { }

        public UserInfo(UserInfoParameters parameters)
        {
            this.name = parameters.name;
            this.password_hash = parameters.password_hash;
            this.hashing_algorithm = parameters.hashing_algorithm;
            this.tags = parameters.tags;
        }
    }
}
