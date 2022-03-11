using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DSA_Set_and_Map_02.Invenory_Manager
{
    class Program
    {
        // create repo for items
        public static List<Tuple<string, decimal, string>> repository = new List<Tuple<string, decimal, string>>();
        static void Main()
        {
            //keep accepting commands until end is typed
            while (true)
            {
                var input = Console.ReadLine().Split(' ');
                if (input[0] == "end")
                {
                    break;
                }
                //filter commands
                switch (input[0])
                {
                    case "add": AddElement(input);
                        break;
                    case "filter": Filter(input);
                        break;

                }
            }
        }
        public static void AddElement(string[] currentCommand)
        {
            bool exists = false;
            //check if it already exists and if so throw error message
            foreach(var el in repository)
            {
                if(el.Item1 == currentCommand[1])
                {
                    exists = true;
                    Console.WriteLine($"Error: Item {currentCommand[1]} already exists");
                }
            }
            // If it doesnt exist add it to list
            if (exists == false)
            {
                // use invariant culture so both dot and comma can be used for decimal
                var item = Tuple.Create(currentCommand[1], decimal.Parse(currentCommand[2], CultureInfo.InvariantCulture), currentCommand[3]);
                repository.Add(item);
                Console.WriteLine($"Ok: Item {currentCommand[1]} added successfully");
            }
        }
        public static void Filter(string[] currentCommand)
        {
            
            string filterCondition = currentCommand[2];
            string[] filterVariable = currentCommand;

            switch (filterCondition)
            {
                case "type":
                    FilterByType(filterVariable);
                    break;
                case "price":
                    FilterByPrice(filterVariable);
                        break;
            }
        }
        public static void FilterByType(string[] filterVarible)
        {
            bool exists = false;
            foreach(var el in repository)
            {
                if(el.Item3 == filterVarible[3])
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                Console.WriteLine($"Error: Type {filterVarible[3]} does not exist");
            }
            else
            {
                var output = repository.FindAll(tuple => tuple.Item3 == filterVarible[3]);
                var result = output.OrderBy(tuple => tuple.Item2).ThenBy(tuple =>tuple.Item1).ThenBy(tuple=>tuple.Item3);

                int index = 0;
                if (output.Count == 0)
                {
                    Console.WriteLine("Ok:");
                }
                else
                {
                    Console.Write($"Ok:");
                }
                foreach (var el in result)
                {
                    index++;
                    if(index == 11)
                    {
                        break;
                    }
                    if (index == output.Count || index == 10)
                    {
                        Console.WriteLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                    }
                    else
                    {
                        Console.Write($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                    }
                }
            }
        }
        public static void FilterByPrice(string[] filterVariable)
        {
            if(filterVariable.Length == 7)
            {
                List<Tuple<string, decimal, string>> filter = repository.FindAll(tuple => tuple.Item2 > decimal.Parse(filterVariable[4], CultureInfo.InvariantCulture));
                var filter2 = filter.FindAll(tuple => tuple.Item2 < decimal.Parse(filterVariable[6]));
                var result = filter2.OrderBy(tuple => tuple.Item2).ThenBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item3);

                int index = 0;
                if (filter2.Count == 0)
                {
                    Console.WriteLine("Ok:");
                }
                else
                {
                    Console.Write($"Ok:");
                }
                foreach (var el in result)
                {
                    index++;
                    if(index == 11)
                    {
                        break;
                    }
                    if (index == filter2.Count || index == 10)
                    {
                        Console.WriteLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                    }
                    else
                    {
                        Console.Write($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                    }
                }
            }
            if (filterVariable.Length == 5)
            {
                if (filterVariable[3] == "to")
                {
                    List<Tuple<string, decimal, string>> output = repository.FindAll(tuple => tuple.Item2 < decimal.Parse(filterVariable[4], CultureInfo.InvariantCulture));
              
                    var result = output.OrderBy(tuple => tuple.Item2).ThenBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item3);


                    int index = 0;
                    if (output.Count == 0)
                    {
                        Console.WriteLine("Ok:");
                    }
                    else
                    {
                        Console.Write($"Ok:");
                    }
                    foreach (var el in result)
                    {
                        index++;
                        if (index == 11)
                        {
                            break;
                        }
                        if (index == output.Count || index == 10)
                        {
                            Console.WriteLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                        }
                        else
                        {
                            Console.Write($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                        }
                    }
                }
                else if (filterVariable[3] == "from")
                {
                    List<Tuple<string, decimal, string>> output = repository.FindAll(tuple => tuple.Item2 > decimal.Parse(filterVariable[4], CultureInfo.InvariantCulture));
                   
                    var result = output.OrderBy(tuple => tuple.Item2).ThenBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item3);


                    int index = 0;
                    if (output.Count == 0)
                    {
                        Console.WriteLine("Ok:");
                    }
                    else
                    {
                        Console.Write($"Ok:");
                    }
                    foreach (var el in result)
                    {
                        index++;
                        if (index == 11)
                        {
                            break;
                        }
                        if (index == output.Count || index == 10)
                        {
                            Console.WriteLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                        }
                        else
                        {
                            Console.Write($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                        }
                    }
                }
            }
            
        }
    }
}
