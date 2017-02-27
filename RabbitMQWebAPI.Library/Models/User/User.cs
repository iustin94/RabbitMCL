using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.User
{
    public class User: Model
    {
        public string name { get; internal set; }
        public string password_hash { get; internal set;}
        public string hashing_algorithm { get; internal set; }
        public string tags { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
                {
                    "name",
                    "password_hash",
                    "hashing_algorithm",
                    "tags"
                };
            }

            set { Keys = value; }
        }

        public User() { }



       
    }
}
