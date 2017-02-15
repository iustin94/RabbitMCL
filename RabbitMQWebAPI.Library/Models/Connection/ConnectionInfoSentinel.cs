using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Connection;

namespace RabbitMQWebAPI.Library.Models.Channel.Connection
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
