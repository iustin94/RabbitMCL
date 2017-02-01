using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models
{
    public class QueueInfo
    {

        //TODO Enum for states
        public enum StateEnum { Syncing = 0, Running = 1, Idle = 2, Flow = 3, Blocked = 4}

        public string Name;
        public StateEnum State;
        public bool Exclusive;
        public bool AutoDelete;
        public bool Durable;
        public string VHost;

        public QueueInfo(string Name, string State, bool Exclusive, bool AutoDelete, bool Durable, string VHost)
        {
            this.Name = Name;
            this.Exclusive = Exclusive;
            this.AutoDelete = AutoDelete;
            this.Durable = Durable;
            this.VHost = VHost;

            if (State == "syncing") this.State = StateEnum.Syncing;
            if (State == "running") this.State = StateEnum.Running;
            if (State == "idle") this.State = StateEnum.Idle;
            if (State == "flow") this.State = StateEnum.Flow;
            if (State == "blocked") this.State = StateEnum.Blocked;
        }


    }
}
