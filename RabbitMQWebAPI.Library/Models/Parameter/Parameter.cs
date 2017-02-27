using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Parameter
{
    public class Parameter: Model
    {
        public ParameterValue.ParameterValue value { get; internal set; }
        public string vhost { get; internal set; }
        public string component { get; internal set; }
        public string name { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "values",
            "vhost",
            "component",
            "name"
        };
            }

            set { Keys = value; }
        }

        public Parameter() { }
    }
}
