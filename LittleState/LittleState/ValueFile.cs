using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleState
{
    public struct EventInformation
    {
        public bool isRoot;
        public string eventName;
    }

    public struct ReturnObject
    {
        public FunctionResult returnState;
        public StateArgs returnArguments;
        public bool shallContinueProgram;
    }

    public class State
    {
        public EventState current = 0;

        public void Next()
        {
            current++;
        }

        public void Previous()
        {
            current--;
        }

        public virtual void Init()
        {

        }
    }

    public struct StateArgs
    {
        public Exception failException;
        public dynamic payLoad;
    }

    public enum mainState
    {
        Running,
        Paused,
        Done,
        Fail,
        LAST_INDEX
    }

    public enum EventState
    {
        Init,
        Idle,
        Finish,
        Done,
        Fail,
        LAST_INDEX
    }

    /// <summary>
    /// Result options for functions of type ReturnObject.
    /// </summary>
    public enum FunctionResult
    {
        Success,
        Fail,
        LAST_INDEX
    }
}
