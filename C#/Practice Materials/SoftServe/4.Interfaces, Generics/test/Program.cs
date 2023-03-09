using System;
using System.Collections;
using System.Collections.Generic;

namespace test
{
    public class Generic<T>
    {
        public T Field;
        public void TestSub()
        {
            T i = Field + 1;
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            Generic<int> gen = new Generic<int>();
            gen.TestSub();
        }
    }
}
