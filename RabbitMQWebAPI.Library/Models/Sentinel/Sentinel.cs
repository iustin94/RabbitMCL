using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Sentinel
{
    public abstract class Sentinel<IModel> : ISentinel where IModel : Model
    {
        public BaseModel.IModel CreateModel(IDictionary<string, object> parametersDictionary, BaseModel.IModel model)
        {
            if (ValidateDictionary(parametersDictionary, model) != true)
                return default(IModel);
            else
            {
                model = ParseDictionaryToParameters(parametersDictionary);
            }

            return model;
        }

        /// <summary>
        /// Calls dictionary casting to check if it works. Has to be called before T constructor.
        /// </summary>
        /// <param name="parametersDictionary">
        /// </param>
        public abstract BaseModel.IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary);

        public BaseModel.IModel GetModelFromDictionary<IModel>(IDictionary<string, object> dictionary)
        {
            Type type = typeof(IModel);

            var obj = Activator.CreateInstance(type);

            foreach (var kv in dictionary)
            {
                Type propertyType = type.GetProperty(kv.Key).GetType();

                if (propertyType != typeof(System.Reflection.PropertyInfo)) //Not getting this.
                {
                    var obj2 = Activator.CreateInstance(propertyType, new object[] {kv.Value});
                    type.GetProperty(kv.Key).SetValue(obj, obj2);
                }
                else
                {
                    type.GetProperty(kv.Key).SetValue(obj, kv.Value);
                }
            }

            return (BaseModel.IModel)obj;
        }

        /// <summary>
        /// Ensures the dictionary has the expected keys
        /// </summary>
        /// <param name="parametersDictionary"></param>
        /// <returns>True if all keys are present. Throws an exceptiopn with the message to indicate which key is missing</returns>
        public Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary, BaseModel.IModel model)
        {
            foreach (string key in model.Keys)
            {
                if (!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }

        

    }

}
