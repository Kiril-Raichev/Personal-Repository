using System;
using System.Threading;

namespace Task1
{
    class Program
    {
        public class ParallelUtils<T, TR>
        {
            private readonly Func<T, T, TR> operation;
            private readonly T operant1;
            private readonly T operant2;

            public ParallelUtils(Func<T,T,TR> operation, T operant1, T operant2)
            {
                this.operation = operation;
                this.operant1 = operant1;
                this.operant2 = operant2;
            }

            public TR Result { get; private set; }

            public void Evaluate()
            {
                this.Result = operation(operant1, operant2);
            }

            public void StartEvaluation()
            {
                Thread thread = new Thread(Evaluate);
                thread.Start();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
