using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Connection
{
    class ConnectionSentinel : Sentinel<Connection>
    {
        
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            Connection model =new Connection();
            model.connected_at = parametersDictionary["connected_at"].ToString();
            model.type = parametersDictionary["type"].ToString();
            model.client_properties = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["client_properties"].ToString());
            model.vhost = parametersDictionary["vhost"].ToString();
            model.user = parametersDictionary["user"].ToString();
            model.name = parametersDictionary["name"].ToString();
            model.protocol = parametersDictionary["protocol"].ToString();
            model.node = parametersDictionary["node"].ToString();

            return model;
        }

        
    }
}
