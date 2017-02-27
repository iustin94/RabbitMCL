using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.User
{
    public class UserSentinel : Sentinel<User>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            User model = new User();
            model.name = parametersDictionary["name"].ToString();
            model.hashing_algorithm = parametersDictionary["hashing_algorithm"].ToString();
            model.tags = parametersDictionary["tags"].ToString();
            model.password_hash = parametersDictionary["password_hash"].ToString();

            return model;
        }

    }
}
