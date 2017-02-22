using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.BaseModel
{
    public interface IModel
    {
        HashSet<String> Keys { get; set; }
    }
}
