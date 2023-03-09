using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            SportCar sportscar = new SportCar("pejo",1997,90);
            Lory lory = new Lory("mercedes",1004,100);

            sportscar.ShowInfo();
            lory.ShowInfo();
        }
    }

    public abstract class Car
    {
        internal string mark;
        internal int prodYear;

        public Car(string mark, int prodYear)
        {
            this.mark = mark;
            this.prodYear = prodYear;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Mark: {mark}\n" +
                $"Producted in {prodYear}");
        }
    }
    public class SportCar : Car
    {
        internal string mark;
        internal int prodYear;
        private int maxSpeed;

        public SportCar(string mark, int prodYear, int maxSpeed) : base(mark, prodYear)
        {
            this.prodYear = prodYear;
            this.maxSpeed = maxSpeed;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Mark: {mark}\n" +
                $"Producted in {prodYear}\n" +
                $"Maximum speed is {maxSpeed}");
        }
    }
    public class Lory : Car
    {
        internal string mark;
        internal int prodYear;
        private double loadCapacity;

        public Lory(string mark, int prodYear, double loadCapacity) : base(mark, prodYear)
        {
            this.prodYear = prodYear;
            this.loadCapacity = loadCapacity;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Mark: {mark}\n" +
                $"Producted in {prodYear}\n" +
                $"The load capacity is {loadCapacity}");
        }
    }
}
