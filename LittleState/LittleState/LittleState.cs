using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleState
{
    public abstract class LittleEvent
    {
        private EventState _current = 0;
        public EventState current

        {
            get { return _current; }
            set { _current = value; }
        }
    
        private bool _isRoot;
        /// <summary>
        /// The root event shall be the only event which can stop the program if it has finished.
        /// </summary>
        /// 
        public abstract EventInformation info();

        public void ChangeTo(EventState newState)
        {
            _current = newState;
        }

        public abstract void Fail(StateArgs arg);
        public abstract ReturnObject Init();
        public abstract ReturnObject Done();
        public abstract ReturnObject Idle();
        public abstract ReturnObject Finish();
    }

    public abstract class LittleProgram
    {
        public mainState state;
        public abstract void Done();
        public abstract void Fail();
        public abstract ReturnObject Paused();
    }
}
