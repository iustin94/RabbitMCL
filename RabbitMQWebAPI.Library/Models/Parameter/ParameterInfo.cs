using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Parameter
{
    public class ParameterInfo
    {
        public ParameterValue.ParameterValue value { get; private set; }
        public string vhost { get; private set; }
        public string component { get; private set; }
        public string name { get; private set; }

        public ParameterInfo() { }

        public ParameterInfo(ParameterInfoParameters parameters)
        {
            this.value = parameters.value;
            this.vhost = parameters.vhost;
            this.component = parameters.component;
            this.name = parameters.name;
        }
    }
}
