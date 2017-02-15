using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Permission
{
    public struct PermissionInfoParameters
    {
        public string user;
        public string vhost;
        public string configure;
        public string write;
        public string read;
    }
}
