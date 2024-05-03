using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LittleState Tester\n\n");

            while(true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                Console.WriteLine(pressedKey.Key.ToString());
                if (pressedKey.Key == ConsoleKey.Delete)
                {
                    Console.WriteLine("Leo2");
                    break;
                }
            }

            StateMachine();
            Console.WriteLine("StateMachine left. Press key to leave.");
            Console.ReadKey();                      
        }
        
        static void StateMachine()
        {
            LittleState.LittleProgram mainProgram = new Runner();
            LittleState.LittleEvent lEvent = new MenuEvent(); // Program always starts with a menu.

            while (mainProgram.state == LittleState.mainState.Running)
            {
                // New creation to prevent NullReferenceException.                
                LittleState.ReturnObject retObj = new LittleState.ReturnObject();
                LittleState.StateArgs arg = new LittleState.StateArgs();

                switch (lEvent.current)
                {
                    case LittleState.EventState.Init: // Init is set as start value. After creation current is always set to Init.
                        {
                            // retObj is the object of the function of this state.
                            retObj = lEvent.Init();
                            arg = retObj.returnArguments;

                            switch (retObj.returnState)
                            {
                                case LittleState.FunctionResult.Success:
                                    {
                                        //Insert commands if the function succeded.
                                        lEvent.ChangeTo(LittleState.EventState.Idle);
                                        break;
                                    }
                                case LittleState.FunctionResult.Fail:
                                    {
                                        //Insert commands to do if the function failed.
                                        lEvent.Fail(arg);
                                        break;
                                    }
                            }
                            break;
                        }
                    case LittleState.EventState.Idle:
                        {
                            retObj = lEvent.Idle(lEvent);
                            arg = retObj.returnArguments;

                            switch (retObj.returnState)
                            {
                                case LittleState.FunctionResult.Success:
                                    {
                                        //Insert commands if the function succeded.
                                        lEvent.ChangeTo(LittleState.EventState.Finish);
                                        break;
                                    }
                                case LittleState.FunctionResult.Fail:
                                    {
                                        //Insert commands to do if the function failed.
                                        lEvent.Fail(arg);
                                        break;
                                    }
                            }
                            break;
                        }
                    case LittleState.EventState.Finish:
                        {
                            retObj = lEvent.Finish();
                            arg = retObj.returnArguments;

                            switch (retObj.returnState)
                            {
                                case LittleState.FunctionResult.Success:
                                    {
                                        //Insert commands if the function succeded.
                                        lEvent.ChangeTo(LittleState.EventState.Done);
                                        break;
                                    }
                                case LittleState.FunctionResult.Fail:
                                    {
                                        //Insert commands to do if the function failed.
                                        lEvent.Fail(arg);
                                        break;
                                    }
                            }
                            break;
                        }
                    case LittleState.EventState.Done:
                        {
                            retObj = lEvent.Done();
                            arg = retObj.returnArguments;

                            switch (retObj.returnState)
                            {
                                case LittleState.FunctionResult.Success:
                                    {
                                        //Insert commands if the function succeded.
                                        break;
                                    }
                                case LittleState.FunctionResult.Fail:
                                    {
                                        //Insert commands to do if the function failed.
                                        lEvent.Fail(arg);
                                        break;
                                    }
                            }

                            // Set to paused if que is empty and menu has endet.
                            if (MainValues.eventQue.Count == 0 && lEvent.info().isRoot == true)
                            {
                                mainProgram.state = LittleState.mainState.Paused;
                            }
                            // If que is not empty execute next event.
                            else if (MainValues.eventQue.Count > 0)
                            {
                                lEvent = MainValues.eventQue[0];
                                MainValues.eventQue.RemoveAt(0);
                            }
                            // If last item of the que has endet and it was not the menu, go to the menu.
                            else if (MainValues.eventQue.Count == 0 && lEvent.info().isRoot != true)
                            {
                                Console.WriteLine("Letztes Item. Zur&uumlck zum Menu");
                                lEvent = new MenuEvent();
                            }

                            break;
                        }
                }

                switch (mainProgram.state)
                {
                    case LittleState.mainState.Done:
                        {
                            mainProgram.Done();
                            break;
                        }
                    case LittleState.mainState.Fail:
                        {
                            mainProgram.Fail();
                            break;
                        }
                    case LittleState.mainState.Paused:
                        {
                            LittleState.ReturnObject retObjPrg = mainProgram.Paused();

                            if(retObjPrg.shallContinueProgram)
                            {
                                mainProgram.state = LittleState.mainState.Running;
                                lEvent.current = LittleState.EventState.Init;
                            }
                            break;
                        }
                }
            }

            Console.ReadKey();
        }
    }  
}
