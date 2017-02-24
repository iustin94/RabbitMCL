using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Definition.DefinitionUser;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionUser
{
    public class DefinitionUser: Model
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        [JsonProperty(PropertyName = "password_hash")]
        public string password_hash { get; internal set; }

        [JsonProperty(PropertyName = "hashing_algorithm")]
        public string hashing_algorithm { get; internal set; }

        [JsonProperty(PropertyName = "tags")]
        public string tags { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "name",
            "password_hash",
            "hashing_algorithm",
            "tags"
        };
            }

            set { Keys = value; }
        }

        public DefinitionUser() { }
    }
}
