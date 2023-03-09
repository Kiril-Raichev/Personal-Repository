using System;

namespace Task5
{
    class Program
    {
        public delegate int CalcDelegate(int param1,int param2, char operand);

        public  class CalcProgram
        {

            public static int Calc(int param1, int param2, char operand)
            {
                return operand switch
                {
                    (char)43 => param1 + param2,
                    (char)45 => param1 - param2,
                    (char)42 => param1 * param2,
                    (char)47 => (param2 == 0) ? 0 : param1 / param2,
                    _ => 0,
                };
            }
            public object funcCalc = new CalcDelegate(Calc);
          
        }
        static void Main(string[] args)
        {
        }
    }
}
