using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter
{
    public class DefinitionParameter
    {
        public DefinitionParameterValue.DefinitionParameterValue value { get; private set; }
        public string vhost;
        public string component;
        public string name;

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
