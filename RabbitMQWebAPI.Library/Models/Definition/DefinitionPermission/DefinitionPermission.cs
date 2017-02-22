using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionPermission
{
    public class DefinitionPermission
    {

        [JsonProperty(PropertyName = "user")]
        public string user { get; private set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; private set; }

        [JsonProperty(PropertyName = "configure")]
        public string configure { get; private set; }

        [JsonProperty(PropertyName = "write")]
        public string write { get; private set; }

        [JsonProperty(PropertyName = "read")]
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
