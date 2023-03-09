using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        private static StringBuilder output = new StringBuilder();
        private static List<string> patients = new List<string>(150000);
        private static List<int> sorted = new List<int>(150000);
        private static Dictionary<string, int> patientNameCount = new Dictionary<string, int>();
        private static int QueueStartIndex = 0;
        private static int AddedPatients = 0;
        static void Main()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();

                string[] commandLine = inputLine.Split(' ');
                string commandName = commandLine[0];
                string[] parameters = commandLine.Skip(1).ToArray();

                switch (commandName)
                {
                    case "Examine":
                        {
                            output.AppendLine(ExamineCommand(parameters));
                            break;
                        }
                    case "Append":
                        {
                            output.AppendLine(AppendCommand(parameters));
                            break;
                        }
                    case "Insert":
                        {
                            output.AppendLine(InsertCommand(parameters));
                            break;
                        }
                    case "Find":
                        {
                            output.AppendLine(FindCommand(parameters));
                            break;
                        }
                    default:
                        Console.Write(output.ToString());
                        return;
                }
            }
        }
        static string ExamineCommand(string[] parameters)
        {
            int count = int.Parse(parameters[0]);
            if (QueueStartIndex + count > patients.Count || count <= 0)
            {
                return "Error";
            }
            List<int> removed = sorted.GetRange(QueueStartIndex, count);
            QueueStartIndex += count;
            removed.ForEach(p => patientNameCount[patients[p]]--);
            return string.Join(" ", removed.Select(p => patients[p]));
        }

        static string FindCommand(string[] parameters)
        {
            string name = parameters[0];
            if (patientNameCount.TryGetValue(name, out int count))
            {
                return count.ToString();
            }
            return "0";
        }

        static string InsertCommand(string[] parameters)
        {
            int position = int.Parse(parameters[0]) + QueueStartIndex;
            string name = parameters[1];
            if (position < 0 || position > patients.Count)
            {
                return "Error";
            }
            patients.Add(name);
            sorted.Insert(position, AddedPatients++);
            patientNameCount.TryAdd(name, 0);
            patientNameCount[name]++;
            return "OK";
        }

        static string AppendCommand(string[] parameters)
        {
            string name = parameters[0];
            patients.Add(name);
            sorted.Add(AddedPatients++);
            patientNameCount.TryAdd(name, 0);
            patientNameCount[name]++;
            return "OK";
        }
    }
}
