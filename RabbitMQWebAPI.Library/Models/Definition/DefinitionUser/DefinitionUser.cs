using RabbitMQWebAPI.Library.Models.Definition.DefinitionUser;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionUser
{
    public class DefinitionUser
    {
        public string name { get; private set; }
        public string password_hash { get; private set; }
        public string hashing_algorithm { get; private set; }
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
