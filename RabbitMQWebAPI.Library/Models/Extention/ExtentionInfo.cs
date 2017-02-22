using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Extention
{
    public class ExtentionInfo
    {
        [JsonProperty(PropertyName = "javascript")]
        public string javascript { get; private set; }

        public ExtentionInfo() { }

        public ExtentionInfo(ExtentionInfoParameters parameters)
        {
            this.javascript = parameters.javascript;
        }
    }
}