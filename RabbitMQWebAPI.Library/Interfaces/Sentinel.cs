using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Interfaces
{
    public abstract class Sentinel<T,TU> where T: new()
    {
        public T CreateModel()
        {
            return Activator.CreateInstance(typeof(T), TU);
        }
    }
}
