using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RabbitMQWebAPI.Library.Service
{
    public static class Helpers
    {

        public static void DeserializeList(string json)
        {
            JArray info = JsonConvert.DeserializeObject(json);

            foreach (var li in info)
            {
                
            }

        }
    }
}
