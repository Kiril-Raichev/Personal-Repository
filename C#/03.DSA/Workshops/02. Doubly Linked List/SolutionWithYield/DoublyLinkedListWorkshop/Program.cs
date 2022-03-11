using DoublyLinkedListWorkshop;
using System;

class Program
{
    static void Main()
    {
        var list = new LinkedList<int>();
        for (int i = 0; i < 10; i++)
        {
            list.AddLast(i);
        }


        foreach (int item in list)
        {
            Console.WriteLine(item);
        }
    }
}
