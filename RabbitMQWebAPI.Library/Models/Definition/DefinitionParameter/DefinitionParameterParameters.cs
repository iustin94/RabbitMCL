using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter
{
    //Confuzing I know
    public struct DefinitionParameterParameters
    {
        public DefinitionParameterValue.DefinitionParameterValue value;
        public string vhost;
        public string component;
        public string name;
    }
}
