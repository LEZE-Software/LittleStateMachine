using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTester
{
    class GlobalFunctions
    {
        public static void Fail(LittleState.StateArgs arg)
        {
            Console.WriteLine("Fail caused by ", arg.failException.Message);
        }
    }

    class CalculatorFuncitons
    {
        public static LittleState.ReturnObject ReadValues()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            try
            {
                Console.WriteLine("Wert 1: ");
                MainValues.a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Wert 2: ");
                MainValues.b = Convert.ToInt32(Console.ReadLine());
                retObj.returnState = LittleState.FunctionResult.Success;
            }
            catch(Exception ex)
            {
                retObj.returnState = LittleState.FunctionResult.Fail;
                retObj.returnArguments.failException = ex;
            }

            return retObj;
        }
        public static LittleState.ReturnObject CalculateValues(LittleState.LittleEvent eve)
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            try
            {
                MainValues.c = MainValues.a + MainValues.b;
                retObj.returnState = LittleState.FunctionResult.Success;
            }
            catch(Exception ex)
            {
                retObj.returnState = LittleState.FunctionResult.Fail;
                retObj.returnArguments.failException = ex;
            }

            return retObj;
        }
        public static LittleState.ReturnObject OutputValues()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            Console.WriteLine(String.Format("Ergebnis: {0}", MainValues.c.ToString()));
            retObj.returnState = LittleState.FunctionResult.Success;

            return retObj;
        }
        public static LittleState.ReturnObject CalculatorDone()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            return retObj;
        }
        public static LittleState.ReturnObject GetPayload()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            return retObj;
        }
        public static void Fail(LittleState.StateArgs arg)
        {
            Console.WriteLine("Fail caused by ", arg.failException.Message);
        }
    }

    class DisplayFunctions
    {
        public static LittleState.ReturnObject InitDisplay()
        {
            Console.WriteLine("Display Init");
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject IdleDisplay(LittleState.LittleEvent eve)
        {
            Console.WriteLine("Display Idle");
            Console.WriteLine(eve._payload);
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject FinishDisplay()
        {
            Console.WriteLine("Display Finish");
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject DoneDisplay()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            return retObj;
        }

        public static void Fail(LittleState.StateArgs arg)
        {
            Console.WriteLine("Fail caused by ", arg.failException.Message);
        }
    }

    class NameFunctions
    {
        public static LittleState.ReturnObject InitName()
        {
            Console.WriteLine("Name Init");
            Form1 leo = new Form1();
            leo.ShowDialog();

            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject IdleName(LittleState.LittleEvent eve)
        {
            Console.WriteLine("Name Idle");
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject FinishName()
        {
            Console.WriteLine("Name Finish");
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject DoneName()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            return retObj;
        }

        public static void Fail(LittleState.StateArgs arg)
        {
            Console.WriteLine("Fail caused by ", arg.failException.Message);
        }
    }

    class MenuFunctions
    {
        public static LittleState.ReturnObject InitMenu()
        {
            Console.WriteLine("Menu Init");
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject IdleMenu(LittleState.LittleEvent eve)
        {
            Console.WriteLine("Menu Idle 1 für Calc 2 für Name");

            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 0:
                    {
                        Console.WriteLine("Nothing.");
                        break;
                    }
                case 1:
                    {
                        MainValues.eventQue.Add(new CalculatorEvent());
                        break;
                    }
                case 2:
                    {
                        MainValues.eventQue.Add(new NameEvent());
                        break;
                    }
            }
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject FinishMenu()
        {
            Console.WriteLine("Menu Finish");
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject DoneMenu()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            return retObj;
        }
        public static void Fail(LittleState.StateArgs arg)
        {
            Console.WriteLine("Fail caused by ", arg.failException.Message);
        }
    }

    class ProgramFunctions
    {
        /// <summary>
        /// The program has endet succesfully.
        /// </summary>
        public static void Done()
        {

        }

        /// <summary>
        /// The program has endet with an error.
        /// </summary>
        public static LittleState.ReturnObject Fail()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();

            return retObj;
        }

        /// <summary>
        /// The program has been paused.
        /// </summary>
        public static LittleState.ReturnObject Paused()
        {
            LittleState.ReturnObject retObj = new LittleState.ReturnObject();
            Console.WriteLine("Pausiert. \nEnter drücken um fortzufahren. \nEscape drücken um zu beenden");

            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                retObj.shallContinueProgram = true;
            }

            return retObj;
        }
    }
}
