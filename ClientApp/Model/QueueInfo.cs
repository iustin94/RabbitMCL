using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    class QueueInfo
    {
        private string Name;
        private string State;
        private bool Exclusive;
        private bool AutoDelete;
        private bool Durable;
        private string VHost;

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
