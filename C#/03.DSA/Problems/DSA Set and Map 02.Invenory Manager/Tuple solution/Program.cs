using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DSA_Set_and_Map_02.Invenory_Manager
{
    class Program
    {
        private readonly static List<Tuple<string, decimal, string>> repository = new List<Tuple<string, decimal, string>>();
        private readonly static StringBuilder sb = new StringBuilder();
        // create repo for items
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
            Console.WriteLine(sb.ToString().Trim());
        }
        static void AddElement(string[] currentCommand)
        {
            bool exists = false;
            //check if it already exists and if so throw error message
            foreach(var el in repository)
            {
                if(el.Item1 == currentCommand[1])
                {
                    exists = true;
                    sb.AppendLine($"Error: Item {currentCommand[1]} already exists");
                }
            }
            // If it doesnt exist add it to list
            if (exists == false)
            {
                // use invariant culture so both dot and comma can be used for decimal
                var item = Tuple.Create(currentCommand[1], decimal.Parse(currentCommand[2], CultureInfo.InvariantCulture), currentCommand[3]);
                repository.Add(item);
                sb.AppendLine($"Ok: Item {currentCommand[1]} added successfully");
            }
        }
        static void Filter(string[] currentCommand)
        {
            
            string filterCondition = currentCommand[2];

            switch (filterCondition)
            {
                case "type":
                    FilterByType(currentCommand);
                    break;
                case "price":
                    FilterByPrice(currentCommand);
                        break;
            }
        }
        static void FilterByType(string[] command)
        {
            bool exists = false;
            foreach(var el in repository)
            {
                if(el.Item3 == command[3])
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                sb.AppendLine($"Error: Type {command[3]} does not exist");
            }
            else
            {
                var output = repository.FindAll(tuple => tuple.Item3 == command[3]);
                var result = output.OrderBy(tuple => tuple.Item2).ThenBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item3);

                int index = 0;
                if (output.Count == 0)
                {
                    sb.AppendLine("Ok:");
                }
                else
                {
                    sb.Append($"Ok:");
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
                        sb.AppendLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                    }
                    else
                    {
                        sb.Append($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                    }
                }
            }
        }
        static void FilterByPrice(string[] command)
        {
            if(command.Length == 7)
            {
                List<Tuple<string, decimal, string>> filter = repository.FindAll(tuple => tuple.Item2 > decimal.Parse(command[4], CultureInfo.InvariantCulture));
                var filter2 = filter.FindAll(tuple => tuple.Item2 < decimal.Parse(command[6], CultureInfo.InvariantCulture));
                var result = filter2.OrderBy(tuple => tuple.Item2).ThenBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item3);

                int index = 0;
                if (filter2.Count == 0)
                {
                    sb.AppendLine("Ok:");
                }
                else
                {
                    sb.Append($"Ok:");
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
                        sb.AppendLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                    }
                    else
                    {
                        sb.Append($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                    }
                }
            }
            if (command.Length == 5)
            {
                if (command[3] == "to")
                {
                    List<Tuple<string, decimal, string>> output = repository.FindAll(tuple => tuple.Item2 < decimal.Parse(command[4], CultureInfo.InvariantCulture));
              
                    var result = output.OrderBy(tuple => tuple.Item2).ThenBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item3);


                    int index = 0;
                    if (output.Count == 0)
                    {
                        sb.AppendLine("Ok:");
                    }
                    else
                    {
                        sb.Append($"Ok:");
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
                            sb.AppendLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                        }
                        else
                        {
                            sb.Append($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                        }
                    }
                }
                else if (command[3] == "from")
                {
                    List<Tuple<string, decimal, string>> output = repository.FindAll(tuple => tuple.Item2 > decimal.Parse(command[4], CultureInfo.InvariantCulture));
                   
                    var result = output.OrderBy(tuple => tuple.Item2).ThenBy(tuple => tuple.Item1).ThenBy(tuple => tuple.Item3);


                    int index = 0;
                    if (output.Count == 0)
                    {
                        sb.AppendLine("Ok:");
                    }
                    else
                    {
                        sb.Append($"Ok:");
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
                            sb.AppendLine($" {el.Item1}({Math.Round(el.Item2, 2)})");
                        }
                        else
                        {
                            sb.Append($" {el.Item1}({Math.Round(el.Item2, 2)}),");
                        }
                    }
                }
            }
            
        }
    }
}
