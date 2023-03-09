using StackQueueWorkshop.Queue;
using System;

class Program
{
    static void Main(string[] args)
    {
        var queue = new CircularQueue(capacity: 5);
        Console.WriteLine("Add 1,2,3,4,5");
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);

        Console.WriteLine($"CircularQueue contains: {queue}");

        Console.WriteLine("Remove 1,2");
        queue.Dequeue();
        queue.Dequeue();

        Console.WriteLine($"CircularQueue contains: {queue}");

        Console.WriteLine("Add 6,7");
        queue.Enqueue(6);
        queue.Enqueue(7);

        Console.WriteLine($"CircularQueue contains: {queue}");
    }
}
