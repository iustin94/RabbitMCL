using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Consumer.ConsumerChannelDetails
{
    class ConsumerChannelDetailsSentinel : Sentinel<ConsumerChannelDetails>
    {
      
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ConsumerChannelDetails parameters = new ConsumerChannelDetails();
            parameters.name = parametersDictionary["name"].ToString();
            parameters.number = parametersDictionary["number"].ToString();
            parameters.user = parametersDictionary["user"].ToString();
            parameters.connection_name = parametersDictionary["connection_name"].ToString();
            parameters.peer_port = parametersDictionary["peer_port"].ToString();
            parameters.peer_host = parametersDictionary["peer_host"].ToString();

            return parameters;
        }

       
    }
}
