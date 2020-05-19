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
            LittleState.mainState main = LittleState.mainState.Running;
            LittleState.LittleEvent ex;

            ex = new MenuEvent(); // Program always starts with a menu.

            while (main== LittleState.mainState.Running)
            {
                // New creation to prevent NullReferenceException.                
                LittleState.ReturnObject retObj = new LittleState.ReturnObject();
                LittleState.StateArgs arg = new LittleState.StateArgs();

                // ex is the main state.
                switch (ex.current)
                {
                    case LittleState.EventResult.Init: // Init is set as start value. After creation ex.current is always set to Init.
                        {
                            retObj = ex.Init();
                            arg = retObj.returnArguments;

                            if(retObj.returnState == LittleState.FunctionResult.Success)
                            {
                                // ex has been initiated and changes now to idle.
                                ex.ChangeTo(LittleState.EventResult.Idle);
                            }
                            else
                            {
                                ex.Fail(arg);
                            }
                            break;
                        }
                    case LittleState.EventResult.Idle:
                        {
                            retObj = ex.Idle();
                            arg = retObj.returnArguments;

                            if (retObj.returnState == LittleState.FunctionResult.Success)
                            {
                                // ex has been initiated and changes now to idle.
                                ex.ChangeTo(LittleState.EventResult.Finish);
                            }
                            break;
                        }
                    case LittleState.EventResult.Finish:
                        {
                            retObj = ex.Finish();
                            arg = retObj.returnArguments;

                            if (retObj.returnState == LittleState.FunctionResult.Success)
                            {
                                // ex has been initiated and changes now to idle.
                                ex.ChangeTo(LittleState.EventResult.Done);
                            }
                            break;
                        }
                    case LittleState.EventResult.Done:
                        {
                            // Set to paused if que is empty and menu has endet.
                            if(MainValues.eventQue.Count==0 && ex.info().isRoot == true)
                            {
                                main = LittleState.mainState.Paused;
                            }
                            // If que is not empty execute next event.
                            else if(MainValues.eventQue.Count>0)
                            {
                                ex = MainValues.eventQue[0];
                                MainValues.eventQue.RemoveAt(0);
                            }
                            // If last item of the que has endet and it was not the menu, go to the menu.
                            else if(MainValues.eventQue.Count == 0 && ex.info().isRoot != true)
                            {
                                ex = new MenuEvent();
                            }

                            break;
                        }
                }

                switch (main)
                {
                    case LittleState.mainState.Done:
                        {
                            Console.WriteLine("Programm-Ende.");

                            break;
                        }
                    case LittleState.mainState.Fail:
                        {
                            Console.WriteLine("Programm-Ende. Fehlfunktion.");
                            break;
                        }
                    case LittleState.mainState.Paused:
                        {
                            Console.WriteLine("Pausiert. \nEnter drücken um fortzufahren. \nEscape drücken um zu beenden");

                            ConsoleKeyInfo pressedKey = Console.ReadKey();
                            if (pressedKey.Key == ConsoleKey.Enter)
                            {
                                main = LittleState.mainState.Running;
                                ex.current = LittleState.EventResult.Init;
                            }
                            break;
                        }
                }
            }

            Console.ReadKey();          
        }        
    }  
}
