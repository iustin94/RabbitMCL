using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebApi.Library.Models.Binding;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Channel.ConnectionDetails
{
    class ConnectionDetailsSentinel : IParameterSentinel<ConnectionDetails, ConnectionDetailsParameters>
    {

        /// <summary>
        /// The class sentinel. Will throw an exception if the parametersDictionary is missing one of the neccessary key, value paris or if the values can not be cast to the expected data type.
        /// </summary>
        /// <param name="parametersDictionary">
        /// Dictionary needs to have these fields ONLY
        /// vhost:string
        /// source: string
        /// destination: string
        /// destination_type: string
        /// routing_key: string
        /// arguments: Dictionary of type string, string
        /// properties_key: string
        /// </param>

        public ConnectionDetails CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            ConnectionDetails toReturn;

            if (ValidateDictionary(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new ConnectionDetails(ParseDictionaryToParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        public ConnectionDetailsParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ConnectionDetailsParameters parameters = new ConnectionDetailsParameters();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.peer_host = parametersDictionary["peer_host"].ToString();
            parameters.peer_port = parametersDictionary["peer_port"].ToString();

            return parameters;
        }

        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            if (!parametersDictionary.ContainsKey("name"))
                throw new DictionaryMissingArgumentException("name");

            if (!parametersDictionary.ContainsKey("peer_port"))
                throw new DictionaryMissingArgumentException("peer_port");

            if (!parametersDictionary.ContainsKey("peer_host"))
                throw new DictionaryMissingArgumentException("peer_host");

            return true;
        }
    }
}
