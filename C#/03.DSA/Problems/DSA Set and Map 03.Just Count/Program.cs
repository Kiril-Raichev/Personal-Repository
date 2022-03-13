using System;
using System.Collections.Generic;

namespace DSA_Set_and_Map_03.Just_Count
{
    class Program
    {
        static void Main()
        {
            char[] charArray = Console.ReadLine().ToCharArray();

            CheckSpecialLetter(charArray);
            CheckLowerCase(charArray);
            CheckUpperCase(charArray);

        }
        static void CheckLowerCase(char[] charArray)
        {
            //creating dictionary and char array
            var dict = new Dictionary<char, int>();
            List<char> chars = new List<char>();
            //filtering and puttin  lowercase chars to char array
            foreach (var ch in charArray)
            {
                if (Char.IsLetter(ch) && Char.IsLower(ch))
                {
                    chars.Add(ch);
                }
            }
            //adding lowercase chars to dictionary and assigning value equal to number of repeats
            foreach (var el in chars)
            {
                if (!dict.ContainsKey(el))
                {
                    dict.Add(el, 1);
                }
                else
                {
                    dict[el]++;
                }
            }
            //checking the highest value in all of dict values
            int highestCount = 0;
            foreach (var el in dict)
            {
                if (el.Value > highestCount)
                {
                    highestCount = el.Value;
                }
            }
            //one or more chars that have highest value
            List<char> output = new List<char>();
            foreach (var el in dict)
            {
                if (el.Value == highestCount)
                {
                    output.Add(el.Key);
                }
            }
            //output if no matches
            if (chars.Count == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                //output if only one has highest value
                if (output.Count == 1)
                {
                    char key = output[0];
                    int value = dict[key];
                    Console.WriteLine($"{key} {value}");
                }
                //output if two or more have highest value
                else
                {
                    //getting the chat with lowest ascii vlue
                    int lowestAscii = 220;
                    foreach (var el in output)
                    {
                        if ((int)el < lowestAscii)
                        {
                            lowestAscii = (int)el;
                        }
                    }
                    char key = (char)lowestAscii;
                    int value = dict[key];
                    Console.WriteLine($"{key} {value}");
                }
            }

        }
        static void CheckUpperCase(char[] charArray)
        {
            //creating dictionary and char array
            var dict = new Dictionary<char, int>();
            List<char> chars = new List<char>();
            //filtering and puttin  uppercase chars to char array
            foreach (var ch in charArray)
            {
                if (Char.IsLetter(ch) && Char.IsUpper(ch))
                {
                    chars.Add(ch);
                }
            }
            //adding uppercase chars to dictionary and assigning value equal to number of repeats
            foreach (var el in chars)
            {
                if (!dict.ContainsKey(el))
                {
                    dict.Add(el, 1);
                }
                else
                {
                    dict[el]++;
                }
            }
            //checking the highest value in all of dict values
            int highestCount = 0;
            foreach (var el in dict)
            {
                if (el.Value > highestCount)
                {
                    highestCount = el.Value;
                }
            }
            //one or more chars that have highest value
            List<char> output = new List<char>();
            foreach (var el in dict)
            {
                if (el.Value == highestCount)
                {
                    output.Add(el.Key);
                }
            }
            //output if no matches
            if (chars.Count == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                //output if only one has highest value
                if (output.Count == 1)
                {
                    char key = output[0];
                    int value = dict[key];
                    Console.WriteLine($"{key} {value}");
                }
                //output if two or more have highest value
                else
                {
                    //getting the chat with lowest ascii vlue
                    int lowestAscii = 200;
                    foreach (var el in output)
                    {
                        if ((int)el < lowestAscii)
                        {
                            lowestAscii = (int)el;
                        }
                    }
                    char key = (char)lowestAscii;
                    int value = dict[key];
                    Console.WriteLine($"{key} {value}");
                }
            }
        }
        static void CheckSpecialLetter(char[] charArray)
        {
            //creating dictionary and char array
            var dict = new Dictionary<char, int>();
            List<char> chars = new List<char>();
            //filtering and puttin  special chars to char array
            foreach (var ch in charArray)
            {
                if ((int)ch > 31 && (int)ch < 48)
                {
                    chars.Add(ch);
                }
            }
            //adding special chars to dictionary and assigning value equal to number of repeats
            foreach (var el in chars)
            {
                if (!dict.ContainsKey(el))
                {
                    dict.Add(el, 1);
                }
                else
                {
                    dict[el]++;
                }
            }
            //checking the highest value in all of dict values
            int highestCount = 0;
            foreach (var el in dict)
            {
                if (el.Value > highestCount)
                {
                    highestCount = el.Value;
                }
            }
            //one or more chars that have highest value
            List<char> output = new List<char>();
            foreach (var el in dict)
            {
                if (el.Value == highestCount)
                {
                    output.Add(el.Key);
                }
            }
            //output if no matches
            if (chars.Count == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                //output if only one has highest value
                if (output.Count == 1)
                {
                    char key = output[0];
                    int value = dict[key];
                    Console.WriteLine($"{key} {value}");
                }
                //output if two or more have highest value
                else
                {
                    //getting the chat with lowest ascii vlue
                    int lowestAscii = 200;
                    foreach (var el in output)
                    {
                        if ((int)el < lowestAscii)
                        {
                            lowestAscii = (int)el;
                        }
                    }
                    char key = (char)lowestAscii;
                    int value = dict[key];
                    Console.WriteLine($"{key} {value}");
                }
            }
        }
    }
}
