using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Permission
{
    public class PermissionSentinel : Sentinel<Permission>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            Permission parameters = new Permission();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.configure = parametersDictionary["configure"].ToString();
            parameters.write = parametersDictionary["write"].ToString();
            parameters.read = parametersDictionary["read"].ToString();

            return parameters;
        }
    }
}
