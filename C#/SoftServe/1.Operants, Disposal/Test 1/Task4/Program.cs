using System;

namespace Task4
{
    public class Person
    {
        protected int yearOfBirth;
        protected string healthInfo;
        protected string name;

        public Person(int yearOfBirth, string name, string healthInfo)
        {
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }

        public string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }

    }

    public class Child : Person
    {
        private string childIDNumber;
        new private int yearOfBirth;
        new private string healthInfo;
        new private string name;


        public Child(int yearOfBirth, string name, string healthInfo, string childIDNumber) :
            base(yearOfBirth, name, healthInfo)
        {
            this.childIDNumber = childIDNumber;
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }

        public override string ToString()
        {
            return name + " " + childIDNumber;
        }

        new public string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
    }
    public class Adult : Person
    {
        private string passportNumber;
        new private int yearOfBirth;
        new private string healthInfo;
        new private string name;
        public Adult(int yearOfBirth, string name, string healthInfo, string passportNumber) :
            base(yearOfBirth, name, healthInfo)
        {
            this.passportNumber = passportNumber;
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.healthInfo = healthInfo;
        }
        public override string ToString()
        {
            return name + " " + passportNumber;
        }
        new public string GetHealthStatus() { return name + ": " + yearOfBirth + ". " + healthInfo; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Child test = new Child(1998, "simo", "healthy", "1");

        }
    }
}
