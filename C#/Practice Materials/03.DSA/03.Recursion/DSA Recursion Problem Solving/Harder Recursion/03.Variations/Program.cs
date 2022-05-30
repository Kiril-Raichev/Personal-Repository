using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.Variations
{
    class Program
    {
        static List<string> strings = new List<string>();
        static void Main()
        {
            //get input lenght
            int length = int.Parse(Console.ReadLine());

            //get input chrars
            string[] inputArray = Console.ReadLine().Split(' ');
            string input = string.Join("",inputArray);
            char[] charArray = input.ToCharArray();

            //sort chars
            var charList = charArray.ToList();
            charList.Sort();

            //assign them to vars
            char symbol1 = charList[0];
            char symbol2 = charList[1];

            //call method
            Vars(symbol1,symbol2,length, "");
            //print
            //faster?
            Console.WriteLine(string.Join($"{Environment.NewLine}",strings));      
        } 
        static void Vars(char symbol1,char symbol2,int length, string current)
        {
            //check if variation is as long as we want it and add if so
            //remove condition, faster?
            if(current.Length == length)
            {
                strings.Add(current);
                return;
            }
            //recurses twice,so every new variation creates 2 more variations from itself with the 2 symbols
            Vars(symbol1, symbol2, length, current + symbol1);
            Vars(symbol1, symbol2, length, current + symbol2);
        }
    }
}
