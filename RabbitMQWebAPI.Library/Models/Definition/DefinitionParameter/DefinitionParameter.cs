using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter
{
    public class DefinitionParameter
    {
        [JsonProperty(PropertyName = "value")]
        public DefinitionParameterValue.DefinitionParameterValue value { get; private set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; internal set; }

        [JsonProperty(PropertyName = "component")]
        public string component { get; internal set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; internal set; }

        public DefinitionParameter() { }

        public DefinitionParameter(DefinitionParameterParameters parameters)
        {
            this.value = parameters.value;
            this.vhost = parameters.vhost;
            this.component = parameters.component;
            this.name = parameters.name;
        }
    }
}
