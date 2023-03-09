using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester john = new Tester("name", DateTime.Now, true);
            Tester johnf = new Tester("name", DateTime.Now, false);

            john.ShowInfo();
            johnf.ShowInfo();

        }
    }

    public class Employee
    {
        internal string name;
        private DateTime hiringDate;

        public Employee(string name, DateTime hiringDate)
        {
            this.name = name;
            this.hiringDate = hiringDate;
        }

        public int Experience()
        {
            int yearDiff = DateTime.Now.Year - hiringDate.Year;
            if (hiringDate.Month > DateTime.Now.Month)
            {
                yearDiff--;
            }
            else if(hiringDate.Month == DateTime.Now.Month)
            {
                if (hiringDate.Day > DateTime.Now.Day)
                {
                    yearDiff--;
                }
            }
            return yearDiff;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{name} has {Experience()} years of experience");
        }
    }
    public class Developer : Employee
    {
        private string programmingLanguage;

        public Developer(string name, DateTime hiringDate, string programmingLanguage) :
        base(name, hiringDate)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{name} has {Experience()} years of experience\n" +
                $"{name} is {programmingLanguage} programmer");
        }
    }
    public class Tester : Employee
    {
        private bool isAuthomation;

        public Tester(string name, DateTime hiringDate, bool isAuthomation):
            base(name,hiringDate)
        {
            this.isAuthomation = isAuthomation;
        }

        public override void ShowInfo()
        {
            if (isAuthomation)
            {
                Console.WriteLine($"{name} is authomated tester and has {Experience()} years of experience");
            }
            else
            {
                Console.WriteLine($"{name} is manual tester and has {Experience()} years of experience");
            }
        }
    }

}
