using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionUser;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionUser
{
    public class DefinitionUser
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; private set; }

        [JsonProperty(PropertyName = "password_hash")]
        public string password_hash { get; private set; }

        [JsonProperty(PropertyName = "hashing_algorithm")]
        public string hashing_algorithm { get; private set; }

        [JsonProperty(PropertyName = "tags")]
        public string tags { get; private set; }

        public DefinitionUser() { }
        public DefinitionUser(DefinitionUserParameters parameters)
        {
            this.name = parameters.name;
            this.password_hash = parameters.password_hash;
            this.hashing_algorithm = parameters.hashing_algorithm;
            this.tags = parameters.tags;
        }
    }
}
