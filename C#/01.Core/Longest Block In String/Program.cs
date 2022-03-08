using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Longest_Block_In_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            List<char> strList = new List<char>();
            int endingIndex = 0;
            int startingIndex = 0;
            int count = 1;
            int maxSeq = 0;
            foreach (char ch in str)
            {
                strList.Add(ch);
            }

            for (int i = 1; i < strList.Count; i++)
            {
                if (strList[i] == strList[i - 1])
                {     
                    count++;
                }
                else
                {
                    if (maxSeq < count)
                    {
                        maxSeq = count;
                        startingIndex = i - maxSeq;
                        endingIndex = i - 1;
                        count = 1;
                    }
                    count = 1;
                }
            }
            for (int a = startingIndex; a<= endingIndex; a++)
            {
                Console.Write(strList[a]);
            }
        }
    }
}
