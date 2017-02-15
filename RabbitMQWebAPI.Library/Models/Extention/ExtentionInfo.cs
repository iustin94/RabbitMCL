using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Extention
{
    public class ExtentionInfo
    {
        public string javascript { get; private set; }

        public ExtentionInfo() { }

        public ExtentionInfo(ExtentionInfoParameters parameters)
        {
            this.javascript = parameters.javascript;
        }
    }
}
