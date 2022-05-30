using DoublyLinkedListWorkshop;
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        var list = new LinkedList<Point>();
        var p1 = new Point() { X = 1, Y = 1 };
        list.AddFirst(p1);
        var p2 = new Point() { X = 3, Y = 3 };
        list.AddLast(p2);

        var target = new Point() { X = 3, Y = 3 };
        var index = list.IndexOf(target);
        Console.WriteLine(index);
    }
}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    //public override bool Equals(object obj)
    //{
    //    var other = (Point)obj;
    //    return this.X == other.X && this.Y == other.Y;
    //}
}

