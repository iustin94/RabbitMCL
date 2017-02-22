using System;
using System.Collections.Generic;

namespace RabbitMQWebAPI.Library.Models.Sentinel
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
    public abstract class Sentinel<IModel,U>:ISentinel<IModel,U> where IModel : new() where U: new() 
    { 
        public IModel CreateModel(IDictionary<string, object> parametersDictionary)
        {
            IModel toReturn ;

            if (ValidateDictionary(parametersDictionary) != true)
                return default(IModel);
            else
            {
                U parameters = ParseDictionaryToParameters(parametersDictionary);
                toReturn = (IModel)Activator.CreateInstance(typeof(IModel), new object[] {parameters});
            }

            //If we got this far then everything should be fine.
            return toReturn;
        }


        /// <summary>
        /// Calls dictionary casting to check if it works. Has to be called before T constructor.
        /// </summary>
        /// <param name="parametersDictionary">
        /// </param>
        public abstract U ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary);

        /// <summary>
        /// Ensures the dictionary has the expected keys
        /// </summary>
        /// <param name="parametersDictionary"></param>
        /// <returns>True if all keys are present. Throws an exceptiopn with the message to indicate which key is missing</returns>
        public abstract Boolean ValidateDictionary(IDictionary<string, object> parametersDictionary);

    }
}
