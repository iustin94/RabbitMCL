using System;
using System.Collections.Generic;

namespace RabbitMQWebAPI.Library.Models.BaseModel
{
    public abstract class Model: IModel
    {
        public  abstract HashSet<String> Keys { get; set; }
    }
}
