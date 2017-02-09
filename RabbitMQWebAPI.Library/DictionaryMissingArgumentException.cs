using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library
{
    class DictionaryMissingArgumentException: Exception
    {
        public DictionaryMissingArgumentException()
        {
            
        }

        public DictionaryMissingArgumentException(string argument)
            : base(string.Format("Arguments dictionary does not contain \"{0}\" key.", argument))
        {
            
        }

        public DictionaryMissingArgumentException(string argument, Exception inner) 
            : base(string.Format("Arguments dictionary does not contain \"{0}\" key.", argument), inner)
        {
            
        }
    }
}
