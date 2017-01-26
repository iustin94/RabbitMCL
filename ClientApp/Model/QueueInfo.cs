using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    class QueueInfo
    {
        public string Name;
        public string State;
        public bool Exclusive;
        public bool AutoDelete;
        public bool Durable;
        public string VHost;

        public QueueInfo(string Name, string State, bool Exclusive, bool AutoDelete, bool Durable, string VHost)
        {
            this.Name = Name;
            this.State = State;
            this.Exclusive = Exclusive;
            this.AutoDelete = AutoDelete;
            this.Durable = Durable;
            this.VHost = VHost;
        }


    }
}
