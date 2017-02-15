using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Permission
{
    public class PermissionInfo
    {
        public string user { get; private set; }
        public string vhost { get; private set; }
        public string configure { get; private set; }
        public string write { get; private set; }
        public  string read { get; private set; }

        public PermissionInfo() { }

        public PermissionInfo(PermissionInfoParameters parameters)
        {
            this.user = parameters.user;
            this.vhost = parameters.vhost;
            this.configure = parameters.configure;
            this.write = parameters.write;
            this.read = parameters.read;
        }
    }
}
