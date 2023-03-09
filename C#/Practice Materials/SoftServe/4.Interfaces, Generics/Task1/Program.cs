using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        interface IShape
        {
            double Area()
            {
                return 0;
            }
        }
        class Rectangle : IShape
        {
            public double Length { get; set; }
            public double Width { get; set; }


            public double Area()
            {
                return Width * Length;
            }
        }
        class Trapezoid : IShape
        {
            public double Length1 { get; set; }
            public double Length2 { get; set; }

            public double Width { get; set; }


            public double Area()
            {
                return (((Length1 + Length2) / 2) * Width);
            }
        }
        public interface ICloneable
        {
            object Clone();
        }
        class Room<T> : ICloneable, IComparable where T : IShape
        {
            public double Height { get; set; }
            public T Floor { get; set; }
            public double Area { get => Floor.Area(); }

            public object Clone()
            {
                    
                    return new Room<T>
                    {
                        Height = this.Height,
                        Floor = (T)Activator.CreateInstance(typeof(T), new object[] {})
                    };
            }

            public int CompareTo(object obj)
            {
                Room<T> room = obj as Room<T>;
                if (room != null)
                {
                    return this.Area.CompareTo(room.Area);
                }
                else
                {
                    throw new Exception();
                }
            }

            public double Volume()
            {
                double area = Floor.Area();
                return Height * area;
            }
        }

        interface IComparer
        {
            int Compare(object o1, object o2);
        }
        class RoomComparerByVolume<T> : IComparer where T : IShape
        {
            public int Compare(object o1, object o2)
            {
                Room<T> r1 = o1 as Room<T>;
                Room<T> r2 = o2 as Room<T>;
                double v1 = r1.Volume();
                double v2 = r2.Volume();
                if (v1 > v2)
                {
                    return 1;
                }
                else if (v1 < v2)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
