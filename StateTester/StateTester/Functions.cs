using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTester
{
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
        public static LittleState.ReturnObject CalculateValues()
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
            Console.ReadKey();
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject IdleName()
        {
            Console.WriteLine("Name Idle");
            Console.ReadKey();
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject FinishName()
        {
            Console.WriteLine("Name Finish");
            Console.ReadKey();
            return new LittleState.ReturnObject();
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
            Console.ReadKey();
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject IdleMenu()
        {
            Console.WriteLine("Menu Idle 1 für Calc 2 für Name");

            int c = Convert.ToInt32(Console.ReadLine());
            if(c==1)
            {
                MainValues.eventQue.Add(new CalculatorEvent());
            }
            else if (c==2)
            {
                MainValues.eventQue.Add(new NameEvent());
            }

            Console.ReadKey();
            return new LittleState.ReturnObject();
        }
        public static LittleState.ReturnObject FinishMenu()
        {
            Console.WriteLine("Menu Finish");
            Console.ReadKey();
            return new LittleState.ReturnObject();
        }
        public static void Fail(LittleState.StateArgs arg)
        {
            Console.WriteLine("Fail caused by ", arg.failException.Message);
        }
    }
}
