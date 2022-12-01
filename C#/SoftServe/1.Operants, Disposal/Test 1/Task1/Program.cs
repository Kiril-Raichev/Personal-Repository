using System;

namespace ConsoleApp2
{
    class MyAccessModifiers
    {

        private int birthYear;

        protected string personalInfo;

        private protected string IdNumber;

        public MyAccessModifiers(int birthYear, string IdNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.IdNumber = IdNumber;
            this.personalInfo = personalInfo;
        }

        public int Age { get => DateTime.Now.Year - birthYear; }

        private readonly byte averageMiddleAge = 50;
        internal string Name { get; set; }
        public string NickName { get; internal set; }
        protected internal void HasLivedHalfOfLife() { }

        public override bool Equals(object obj)
        {
            return obj is MyAccessModifiers modifiers &&
                   birthYear == modifiers.birthYear &&
                   personalInfo == modifiers.personalInfo &&
                   IdNumber == modifiers.IdNumber &&
                   Age == modifiers.Age &&
                   averageMiddleAge == modifiers.averageMiddleAge &&
                   Name == modifiers.Name &&
                   NickName == modifiers.NickName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(birthYear, personalInfo, IdNumber, Age, averageMiddleAge, Name, NickName);
        }

        public static bool operator ==(MyAccessModifiers a, MyAccessModifiers b)
        {
            if (a.Name.Equals(b.Name) && a.Age.Equals(b.Age) && a.personalInfo.Equals(b.personalInfo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(MyAccessModifiers a, MyAccessModifiers b)
        {
            if (!a.Name.Equals(b.Name) && !a.Age.Equals(b.Age) && !a.personalInfo.Equals(b.personalInfo))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyAccessModifiers test = new MyAccessModifiers(2002, "1", "Tom");
            MyAccessModifiers test1 = new MyAccessModifiers(2002, "1", "Tom");

            if (test == test1) Console.WriteLine("True");
            else Console.WriteLine("False");
        }
    }
}

