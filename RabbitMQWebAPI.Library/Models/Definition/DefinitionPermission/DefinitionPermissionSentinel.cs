using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission
{
    class PermissionSentinel : Sentinel<DefinitionPermission>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionPermission parameters = new DefinitionPermission();
            parameters.configure = parametersDictionary["configure"].ToString();
            parameters.read = parametersDictionary["read"].ToString();
            parameters.write = parametersDictionary["write"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.user = parametersDictionary["user"].ToString();

            return parameters;
        }
    }
}
