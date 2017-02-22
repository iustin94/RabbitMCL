using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Binding
{
    /// <summary>
    /// Class that inspects parameters before creating a BindingInfo. This prevents creation of invalid objects. Use this to create the BindingInfo object then store that object.
    /// </summary>
    public class BindingInfoSentinel: SentinelNew<BindingInfo>
    {
        public override BaseModel.IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary, BaseModel.IModel model)
        {
            BindingInfo binding = new BindingInfo();
            binding.source = parametersDictionary["source"].ToString();
            binding.vhost = parametersDictionary["vhost"].ToString();
            binding.arguments = JsonConvert.DeserializeObject<
                                   Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            binding.destination = parametersDictionary["destination"].ToString();
            binding.destination_type = parametersDictionary["destination_type"].ToString();
            binding.properties_key = parametersDictionary["properties_key"].ToString();
            binding.routing_key = parametersDictionary["routing_key"].ToString();

            return binding;
        }
    }
}
