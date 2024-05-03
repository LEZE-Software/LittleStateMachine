using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubForm
{
    public class Event
    {
        public EventType localType { get; private set; }

        public Event(EventType _Type)
        {
            localType = _Type;
        }
    }

    public enum EventType
    {
        NOT_SET,
        NEW_ENTRY,
        MET_NPC,
        TOGGLED_BUTTON
    }
}
