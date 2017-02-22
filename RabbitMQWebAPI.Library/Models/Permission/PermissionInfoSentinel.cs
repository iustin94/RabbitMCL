using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Permission
{
    public class PermissionInfoSentinel : Sentinel<PermissionInfo, PermissionInfoParameters>
    {
        public override PermissionInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            PermissionInfoParameters parameters = new PermissionInfoParameters();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.configure = parametersDictionary["configure"].ToString();
            parameters.write = parametersDictionary["write"].ToString();
            parameters.read = parametersDictionary["read"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in PermissionInfoKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
