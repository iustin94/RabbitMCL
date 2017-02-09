using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Channel.Connection
{
    class ConnectionInfoSentinel : IParameterSentinel<ConnectionInfo, ConnectionInfoParameters>
    {
        public ConnectionInfo CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            ConnectionInfo toReturn;

            if (ValidateDictionary(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new ConnectionInfo(ParseDictionaryToParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        public ConnectionInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
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

        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            if(!parametersDictionary.ContainsKey("connected_at"))
                throw new DictionaryMissingArgumentException("connected_at");
            if (!parametersDictionary.ContainsKey("type"))
                throw new DictionaryMissingArgumentException("type");
            if (!parametersDictionary.ContainsKey("client_properties"))
                throw new DictionaryMissingArgumentException("client_properties");
            if (!parametersDictionary.ContainsKey("vhost"))
                throw new DictionaryMissingArgumentException("vhost");
            if (!parametersDictionary.ContainsKey("user"))
                throw new DictionaryMissingArgumentException("user");
            if (!parametersDictionary.ContainsKey("name"))
                throw new DictionaryMissingArgumentException("name");
            if (!parametersDictionary.ContainsKey("protocol"))
                throw new DictionaryMissingArgumentException("protocol");
            if (!parametersDictionary.ContainsKey("node"))
                throw new DictionaryMissingArgumentException("node");

            return true;
        }
    }
}
