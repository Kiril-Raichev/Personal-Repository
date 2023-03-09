using System;
using System.Linq;
namespace Move
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());
            long[] array = Console.ReadLine().Split(',').Select(long.Parse).ToArray();
            string command = Console.ReadLine();
            long forwardSum = 0;
            long backwardsSum = 0;
            while(command != "exit")
            {
                string[] current = command.Split(' ');
                int numberOfMoves = int.Parse(current[0]);
                string direction = current[1];
                int size = int.Parse(current[2]);            

                if (direction == "forward")
                {
                   
                    for (int i = 0; i < numberOfMoves; i++)
                    {
                        index += size;
                        if (index <= array.Length - 1)
                        {
                            forwardSum += array[index];
                        }
                        else
                        {
                            index = index % array.Length;
                            forwardSum += array[index];
                        }
                        
                    }
                }
                if(direction == "backwards")
                {
                   
                    for (int i = 0; i < numberOfMoves; i++)
                    {
                        index -= size;
                        if(index < 0)
                        {
                            index = array.Length + index;
                            backwardsSum += array[index];
                        }
                        else
                        {
                            backwardsSum += array[index];
                        }
                    }
                }



                string nextCommand = Console.ReadLine();
                command = nextCommand;
            }
            Console.WriteLine($"Forward: {forwardSum}");
            Console.WriteLine($"Backwards: {backwardsSum}");

        }
    }
}
