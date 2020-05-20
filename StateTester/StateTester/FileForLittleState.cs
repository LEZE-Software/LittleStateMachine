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

    class CalculatorEvent : LittleState.LittleEvent
    {
        public override  LittleState.EventInformation info() => 
            new LittleState.EventInformation { eventName = "Calculator", isRoot = false };
        public override LittleState.ReturnObject Init() => CalculatorFuncitons.ReadValues();
        public override LittleState.ReturnObject Idle() => CalculatorFuncitons.CalculateValues();
        public override LittleState.ReturnObject Finish() => CalculatorFuncitons.OutputValues();
        public override LittleState.ReturnObject Done() => CalculatorFuncitons.CalculatorDone();

        public override void Fail(LittleState.StateArgs arg) => CalculatorFuncitons.Fail(arg);
    }

    class NameEvent : LittleState.LittleEvent
    {
        public override LittleState.EventInformation info() =>
            new LittleState.EventInformation { eventName = "Name", isRoot = false };

        public override LittleState.ReturnObject Init() => NameFunctions.InitName();
        public override LittleState.ReturnObject Idle() => NameFunctions.IdleName();
        public override LittleState.ReturnObject Finish() => NameFunctions.FinishName();
        public override LittleState.ReturnObject Done() => NameFunctions.DoneName();

        public override void Fail(LittleState.StateArgs arg) => GlobalFunctions.Fail(arg);
    }

    class MenuEvent : LittleState.LittleEvent
    {
        public override LittleState.EventInformation info() =>
            new LittleState.EventInformation { eventName = "Menu", isRoot = true };

        public override LittleState.ReturnObject Init() => MenuFunctions.InitMenu();
        public override LittleState.ReturnObject Idle() => MenuFunctions.IdleMenu();
        public override LittleState.ReturnObject Finish() => MenuFunctions.FinishMenu();
        public override LittleState.ReturnObject Done() => MenuFunctions.DoneMenu();

        public override void Fail(LittleState.StateArgs arg) => MenuFunctions.Fail(arg);
    }
}
