using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelConnectionDetails
{
    public class ChannelConnectionDetailsSentinel : Sentinel<ChannelConnectionDetails>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            ChannelConnectionDetails model = new ChannelConnectionDetails();
            model.name = parametersDictionary["name"].ToString();
            model.peer_host = parametersDictionary["peer_host"].ToString();
            model.peer_port = parametersDictionary["peer_port"].ToString();

            return model;
        }
    }
}
