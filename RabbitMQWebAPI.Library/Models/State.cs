using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models
{
    public class State
    {
        public enum StateEnum { Syncing = 0, Running = 1, Idle = 2, Flow = 3, Blocked = 4 }

        public static StateEnum EvaluateState( string State)
        {
            if (State == "syncing")
                return Models.State.StateEnum.Syncing;
            if (State == "running")
                return Models.State.StateEnum.Running;
            if (State == "idle")
                return Models.State.StateEnum.Idle;
            if (State == "flow")
                return Models.State.StateEnum.Flow;
            if (State == "blocked")
                return Models.State.StateEnum.Blocked;

            throw new Exception("Could not evaluate state.");
        }
    }
}
