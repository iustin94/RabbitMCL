using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionQueue
{
    public class DefinitionQueueSentinel : Sentinel<DefinitionQueue>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            DefinitionQueue model = new DefinitionQueue();
            model.auto_delete = Boolean.Parse(parametersDictionary["auto_delete"].ToString());
            model.durable = Boolean.Parse(parametersDictionary["durable"].ToString());
            model.name = parametersDictionary["name"].ToString();
            model.vhost = parametersDictionary["vhost"].ToString();
            model.arguments = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());

            return model;
        }
    }
}
