using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.DataAccess
{
    class Model
    {
        public enum ModelEnum
        {
            Binding = 0,
            Channel = 1,
            Connection = 2,
            Consumer = 3,
            Definition = 4,
            Exchange = 5,
            Extention = 6,
            Node = 7,
            Parameter = 8,
            Policy = 9,
            Queue = 10,
            User = 11,
            Vhost = 12
        }

        public static ModelEnum EvaluateState(string State)
        {
          
            if(State == "binding")
                return ModelEnum.Binding;
            else if(State == "channel")
                return ModelEnum.Channel;
            else if(State == "connection")
                return ModelEnum.Connection;
            else if(State == "consumer")
                return ModelEnum.Consumer;
            else if(State == "definition")
                return ModelEnum.Definition;
            else if(State == "exchange")
                return ModelEnum.Exchange;
            else if(State == "extention")
                return ModelEnum.Extention;
            else if(State == "node")
                return ModelEnum.Node;
            else if(State == "parameter")
                return ModelEnum.Parameter;
            else if(State == "policy")
                return ModelEnum.Policy;
            else if(State == "queue")
                return ModelEnum.Queue;
            else if(State == "user")
                return ModelEnum.User;
            else if (State == "vhost")
                return ModelEnum.Vhost;  

            throw new Exception("Could not evaluate State.");
        }
    }
}
