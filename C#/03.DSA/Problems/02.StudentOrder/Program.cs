using System;
using System.Linq;

namespace DSAProblem2.StudentOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesAndChanges = Console.ReadLine().Split(' ');
            int numberOfNames = int.Parse(namesAndChanges[0]);
            int numberOfChanges = int.Parse(namesAndChanges[1]);
            string[] studentsArray = Console.ReadLine().Split(' ');

            for(int i = 0; i < numberOfChanges; i++)
            {

                string[] currentCommand = Console.ReadLine().Split(' ');
                string studentToMove = currentCommand[0];
                string studentToFind = currentCommand[1];

                var studentToMoveIndex = Array.IndexOf(studentsArray, studentToMove);
                var studentToFindIndex = Array.IndexOf(studentsArray, studentToFind);

                if (studentToMoveIndex > studentToFindIndex)
                {
                    for (int s = studentToMoveIndex; s > studentToFindIndex; s--)
                    {
                        string buffer = studentsArray[s];
                        studentsArray[s] = studentsArray[s - 1];
                        studentsArray[s - 1] = buffer;
                    }
                }
                else
                {
                    for (int s = studentToMoveIndex; s<studentToFindIndex - 1; s++)
                    {
                        string buffer = studentsArray[s];
                        studentsArray[s] = studentsArray[s + 1];
                        studentsArray[s + 1] = buffer;
                    }
                }
            }

            foreach(string s in studentsArray)
            {
                Console.Write($"{s} ");
            }

        }
    }
}
