using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebApi.Library.Models;
using RabbitMQWebApi.Library.Models.Binding;

namespace RabbitMQWebAPI.Library.Models.Binding
{
    /// <summary>
    /// Class that inspects parameters before creating a BindingInfo. This prevents creation of invalid objects. Use this to create the BindingInfo object then store that object.
    /// </summary>
    public static class BingindInfoSentinel
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
        public static BindingInfo CreateBindingInfo(IDictionary<string, object> parametersDictionary)
        {
            BindingInfo toReturn;

            if (CheckParatemersDictionaryIfAllKeysArePresent(parametersDictionary) != true)
                return null;
            else
            {
                toReturn = new BindingInfo(ParseDictionaryToBindingParameters(parametersDictionary));
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }

        /// <summary>
        /// Ensures the dictionary has the 
        /// </summary>
        /// <param name="parametersDictionary"></param>
        /// <returns>True if all keys are present. Throws an exceptiopn with the message to indicate which key is missing</returns>
        private static bool CheckParatemersDictionaryIfAllKeysArePresent(
            IDictionary<string, object> parametersDictionary)
        {
            if (!parametersDictionary.ContainsKey("vhost"))
            {
                throw new Exception("Arguments dictionary does not contain \"vhost\" key.");
            }

            if (!parametersDictionary.ContainsKey("source"))
            {
                throw new Exception("Arguments dictionary does not contain \"source\" key.");
            }

            if (parametersDictionary.ContainsKey("destination"))
            {
                throw new Exception("Arguments dictionary does not contain \"destination\'");
            }

            if (parametersDictionary.ContainsKey("destination_type"))
            {
                throw new Exception("Arguments dictionary does not contain \"destination_type\" of value type String");
            }

            if (parametersDictionary.ContainsKey("routing_key"))
            {
                throw new Exception("Arguments dictionary does not contain \"routing_key\" of value type string");
            }

            if (parametersDictionary.ContainsKey("arguments"))
            {
                throw new Exception("Arguments dictionary does not contain \"arguments\" of value type Dictionary<string, string>");
            }

            if (parametersDictionary.ContainsKey("properties_key"))
            {
                throw new Exception("Arguments dictionary does not containe \"properties_key\" key of value type string");
            }

            return true;
        }

        /// <summary>
        /// Calls dictionary casting to check if it works. Has to be called before binding info constructor.
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
        /// <returns>Returns struct containing the parsed parameters for BindingInfo</returns>
        private static BindingInfoParameters ParseDictionaryToBindingParameters(
            IDictionary<string, object> parametersDictionary)
        {

            BindingInfoParameters parameters = new BindingInfoParameters();
            parameters.source = parametersDictionary["source"].ToString();
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.arguments = JsonConvert.DeserializeObject<
                                   Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            parameters.destination = parametersDictionary["destination"].ToString();
            parameters.destination_type = parametersDictionary["destination_type"].ToString();
            parameters.properties_key = parametersDictionary["properties_key"].ToString();
            parameters.routing_key = parametersDictionary["routing_key"].ToString();

            return parameters;
        }

    }
}
