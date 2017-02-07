using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models
{
    public class State
    {
        public enum QueueStateEnum { Syncing = 0, Running = 1, Idle = 2, Flow = 3, Blocked = 4 }

        public static QueueStateEnum EvaluateState( string State)
        {
            if (State == "syncing")
                return Models.State.QueueStateEnum.Syncing;
            if (State == "running")
                return Models.State.QueueStateEnum.Running;
            if (State == "idle")
                return Models.State.QueueStateEnum.Idle;
            if (State == "flow")
                return Models.State.QueueStateEnum.Flow;
            if (State == "blocked")
                return Models.State.QueueStateEnum.Blocked;

            throw new Exception("Could not evaluate queueState.");
        }
    }
}
