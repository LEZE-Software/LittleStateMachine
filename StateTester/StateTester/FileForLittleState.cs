using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTester
{
    class Runner : LittleState.LittleProgram
    {
        public override void Done() => ProgramFunctions.Done();
        public override void Fail() => ProgramFunctions.Fail();
        public override LittleState.ReturnObject Paused() => ProgramFunctions.Paused();
    }

    class DisplayEvent : LittleState.LittleEvent
    {
        public override LittleState.EventInformation info() =>
            new LittleState.EventInformation { eventName = "Display", isRoot = false };
        public override LittleState.ReturnObject Init() => DisplayFunctions.InitDisplay();
        public override LittleState.ReturnObject Idle(LittleState.LittleEvent eve) => DisplayFunctions.IdleDisplay(eve);
        public override LittleState.ReturnObject Finish() => DisplayFunctions.FinishDisplay();
        public override LittleState.ReturnObject Done() => DisplayFunctions.DoneDisplay();
        public override void Fail(LittleState.StateArgs arg) => DisplayFunctions.Fail(arg);
    }

    class CalculatorEvent : LittleState.LittleEvent
    {
        public override  LittleState.EventInformation info() => 
            new LittleState.EventInformation { eventName = "Calculator", isRoot = false };
        public override LittleState.ReturnObject Init() => CalculatorFuncitons.ReadValues();
        public override LittleState.ReturnObject Idle(LittleState.LittleEvent eve) => CalculatorFuncitons.CalculateValues(eve);
        public override LittleState.ReturnObject Finish() => CalculatorFuncitons.OutputValues();
        public override LittleState.ReturnObject Done() => CalculatorFuncitons.CalculatorDone();

        public override void Fail(LittleState.StateArgs arg) => CalculatorFuncitons.Fail(arg);
    }

    class NameEvent : LittleState.LittleEvent
    {
        public override LittleState.EventInformation info() =>
            new LittleState.EventInformation { eventName = "Name", isRoot = false };

        public override LittleState.ReturnObject Init() => NameFunctions.InitName();
        public override LittleState.ReturnObject Idle(LittleState.LittleEvent eve) => NameFunctions.IdleName(eve);
        public override LittleState.ReturnObject Finish() => NameFunctions.FinishName();
        public override LittleState.ReturnObject Done() => NameFunctions.DoneName();

        public override void Fail(LittleState.StateArgs arg) => GlobalFunctions.Fail(arg);
    }

    class MenuEvent : LittleState.LittleEvent
    {
        public override LittleState.EventInformation info() =>
            new LittleState.EventInformation { eventName = "Menu", isRoot = true };

        public override LittleState.ReturnObject Init() => MenuFunctions.InitMenu();
        public override LittleState.ReturnObject Idle(LittleState.LittleEvent eve) => MenuFunctions.IdleMenu(eve);
        public override LittleState.ReturnObject Finish() => MenuFunctions.FinishMenu();
        public override LittleState.ReturnObject Done() => MenuFunctions.DoneMenu();

        public override void Fail(LittleState.StateArgs arg) => MenuFunctions.Fail(arg);
    }
}
