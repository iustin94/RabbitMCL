using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionUser;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionUser
{
    class DefinitionUserSentinel : Sentinel<DefinitionUser>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionUser parameters = new DefinitionUser();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.hashing_algorithm = parametersDictionary["hashing_algorithm"].ToString();
            parameters.password_hash = parametersDictionary["password_hash"].ToString();
            parameters.tags = parametersDictionary["tags"].ToString();

            return parameters;
        }
    }
}
