using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionUser;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionUser
{
    class UserSentinel : Sentinel<DefinitionUser, DefinitionUserParameters>
    {
        public override DefinitionUserParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionUserParameters parameters = new DefinitionUserParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.hashing_algorithm = parametersDictionary["hashin_algorithm"].ToString();
            parameters.password_hash = parametersDictionary["password_hash"].ToString();
            parameters.tags = parametersDictionary["tags"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionUserKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
