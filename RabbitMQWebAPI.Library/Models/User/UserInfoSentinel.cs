using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.User
{
    public class UserInfoSentinel : Sentinel<UserInfo, UserInfoParameters>
    {
        public override UserInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            UserInfoParameters parameters = new UserInfoParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.hashing_algorithm = parametersDictionary["hashing_algorithm"].ToString();
            parameters.tags = parametersDictionary["tags"].ToString();
            parameters.password_hash = parametersDictionary["password_hash"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in UserInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
