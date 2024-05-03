using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubForm
{
    public static class Character
    {
        public static Type charType;
    }

    public abstract class Part
    {
        public Type proto { get; set; }

        public List<EventType> Subs = new List<EventType>();

        public abstract void Init();

        public abstract int HandleNewEvent(Event e);
    }

    public class UserInterface : Part
    {
        public UserInterface() 
        {
            Init();
        }

        public override void Init()
        {
            Subs.Add(EventType.TOGGLED_BUTTON);
            Subs.Add(EventType.MET_NPC);
        }

        public override int HandleNewEvent(Event e)
        {
            switch(e.localType)
            {
                case EventType.TOGGLED_BUTTON:
                    {
                        return 3;
                        break;
                    }
                case EventType.MET_NPC:
                    {
                        return 4;
                    }
            }

            return 0;
        }
    }

    public class GameObject : Part
    {
        public GameObject(Type newType)
        {
            proto = newType;
            Init();
        }

        public override void Init()
        {
            Subs.Add(EventType.NEW_ENTRY);
            Subs.Add(EventType.MET_NPC);
        }

        public override int HandleNewEvent(Event e)
        {
            switch (e.localType)
            {
                case EventType.NEW_ENTRY:
                    {
                        return 1;
                    }
                case EventType.MET_NPC:
                    {
                        return 2;
                    }
            }

            return 0;
        }
    }
}
