using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission
{
    class PermissionSentinel : Sentinel<DefinitionPermission, DefinitionPermissionParameters>
    {
        public override DefinitionPermissionParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionPermissionParameters parameters = new DefinitionPermissionParameters();
            parameters.configure = parametersDictionary["configure"].ToString();
            parameters.read = parametersDictionary["read"].ToString();
            parameters.write = parametersDictionary["write"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.user = parametersDictionary["user"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in DefinitionPermissionKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
