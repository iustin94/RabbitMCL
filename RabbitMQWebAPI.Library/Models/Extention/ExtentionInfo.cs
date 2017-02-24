using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Extention
{
    public class ExtentionInfo: Model
    {
        [JsonProperty(PropertyName = "javascript")]
        public string javascript { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "javascript"
        };
            }

            set { Keys = value; }
        }

        public ExtentionInfo() { }

       
    }
}