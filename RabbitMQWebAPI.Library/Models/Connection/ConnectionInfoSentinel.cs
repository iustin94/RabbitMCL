using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Connection
{
    class ConnectionInfoSentinel : Sentinel<ConnectionInfo, ConnectionInfoParameters>
    {
        
        public override ConnectionInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ConnectionInfoParameters parameters =new ConnectionInfoParameters();
            parameters.connected_at = parametersDictionary["connected_at"].ToString();
            parameters.type = parametersDictionary["type"].ToString();
            parameters.client_properties = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["client_properties"].ToString());
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.protocol = parametersDictionary["protocol"].ToString();
            parameters.node = parametersDictionary["node"].ToString();

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in ConnectionInfoKeys.keys)
            {
                if (!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
