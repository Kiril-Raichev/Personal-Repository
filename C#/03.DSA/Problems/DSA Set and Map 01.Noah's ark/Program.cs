using System;
using System.Collections.Generic;
namespace DSA_Set_and_Map_01.Noah_s_ark
{
    class Program
    {
        static void Main()
        {
            int commandCount = int.Parse(Console.ReadLine());
            var dictionary = new SortedDictionary<string, int>();
            for (int i = 0; i < commandCount; i++)
            {
                string currentAnimal = Console.ReadLine();

                if (!dictionary.ContainsKey(currentAnimal))
                {
                    dictionary.Add(currentAnimal, 1);
                }
                else
                {
                    dictionary[currentAnimal]++;
                }
            }

            foreach (var el in dictionary)
            {
                if (el.Value % 2 == 0)
                {
                    Console.WriteLine($"{el.Key} {el.Value} Yes");
                }
                else
                {
                    Console.WriteLine($"{el.Key} {el.Value} No");

                }
            }
        }
    }
}
