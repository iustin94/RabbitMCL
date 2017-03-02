using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter
{
    public class DefinitionParameter: Model
    {
        [JsonProperty(PropertyName = "value")]
        public DefinitionParameterValue.DefinitionParameterValue value { get; internal set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }

        [JsonProperty(PropertyName = "component")]
        public string component { get; internal set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
         "value",
         "vhost",
         "component",
         "name"
        };
            }

            set { Keys = value; }
        }

        public DefinitionParameter() { }

     }
}
