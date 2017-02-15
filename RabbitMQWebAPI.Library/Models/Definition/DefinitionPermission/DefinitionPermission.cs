using RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission
{
    public class DefinitionPermission
    {
        public string user { get; private set; }
        public string vhost { get; private set; }
        public string configure { get; private set; }
        public string write { get; private set; }
        public string read { get; private set; }

        public DefinitionPermission() { }
        public DefinitionPermission(DefinitionPermissionParameters parameters)
        {
            this.user = parameters.user;
            this.vhost = parameters.vhost;
            this.configure = parameters.configure;
            this.write = parameters.write;
            this.read = parameters.read;
        }

    }
}
