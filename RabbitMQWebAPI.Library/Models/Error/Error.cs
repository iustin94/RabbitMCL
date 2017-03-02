using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Error
{
    public class Error : Model
    {
        public string error { get; internal set; }
        public string reason { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
                {
                    "error",
                    "reason"
                };
            }

            set { Keys = value; }
        }

        public Error() { }

        public override string ToString()
        {
            return "{error:" + error + ",reason:" + reason + "}";
        }
    }
}
