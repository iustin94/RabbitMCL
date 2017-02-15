using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Parameter
{
    public struct ParameterInfoParameters
    {
        public ParameterValue.ParameterValue value;
        public string vhost;
        public string component;
        public string name;
    }
}
