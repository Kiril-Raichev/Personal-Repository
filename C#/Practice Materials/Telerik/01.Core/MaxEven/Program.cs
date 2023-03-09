using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MaxEven
{
    class Program
    {
        private static void showMatch(string text, string regex)
        {
    
            MatchCollection matchList = Regex.Matches(text, regex);
            var list = matchList.Cast<Match>().Select(match => match.Value).ToList();
            
            if(list.Count == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                int biggestEven = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    int current = int.Parse(list[i]);
                    if(current %2 ==0 && current > biggestEven)
                    {
                        biggestEven = current;
                    }
                }
                Console.WriteLine(biggestEven);
            }
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            showMatch(str, @"\d+");
            Console.ReadKey();
        }
    }
}
