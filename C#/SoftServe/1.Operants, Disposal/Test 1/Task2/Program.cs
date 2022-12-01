using System;

namespace Task2
{
    public class Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int[] GetXYPair()
        {
            int[] array = new int[2];
            array[0] = x;
            array[1] = y;
            return array;

        }
        protected internal double Distance(int x, int y)
        {
            int[] array = GetXYPair();
            int x1 = x;
            int y1 = y;
            int x2 = array[0];
            int y2 = array[1];
            double distance = Math.Sqrt(Math.Pow((x2-x1),2) + Math.Pow((y2 - y1), 2));
            return distance;
        }
        protected internal double Distance(Point point)
        {
            int[] array = GetXYPair();
            int x1 = point.x;
            int y1 = point.y;
            int x2 = array[0];
            int y2 = array[1];
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return distance;
        }

        public static explicit operator double(Point point)
        {

            double distance = Math.Sqrt(Math.Pow((point.x), 2) + Math.Pow((point.y), 2));
            return distance;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Point test = new Point(4, 6);
            Point test2 = new Point(3, 2);
            Console.WriteLine(test.Distance(3, 2));
            Console.Write(test.Distance(test2));
        }
    }
}
