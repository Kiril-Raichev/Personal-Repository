using System;

namespace Task3
{
    class Fraction
    {
        private int numerator, denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static string[] Simplify(int a, int b)
        {
            while (a % 2 == 0 && b % 2 == 0)
            {
                a /= 2;
                b /= 2;
                while (a % 3 == 0 && b % 3 == 0)
                {
                    a /= 3;
                    b /= 3;
                }
                while (b % 5 == 0 && b % 5 == 0)
                {
                    a /= 5;
                    b /= 5;
                }
            }
            string[] output = new string[] { a.ToString(), b.ToString() };
            return output;
        }
        public static string operator -(Fraction a, Fraction b)
        {
            if (a.denominator == b.denominator)
            {
                if (a.numerator - b.numerator == a.denominator)
                {
                    return "1";
                }
                else
                {
                    int numResult = a.numerator - b.numerator;
                    return ToString(numResult, a.denominator);
                }
            }
            else
            {
                int closestDen = a.denominator * b.denominator;
                int numA = a.numerator * b.denominator;
                int numB = b.numerator * a.denominator;

                return ToString(numA-numB, closestDen);
            }
        }
        public static string operator +(Fraction a, Fraction b)
        {

            if (a.denominator == b.denominator)
            {
                if (a.numerator + b.numerator == a.denominator)
                {
                    return "1";
                }
                else
                {
                    int numResult = a.numerator + b.numerator;
                    return ToString(numResult, a.denominator);
                }
            }
            else
            {
                int closestDen = a.denominator * b.denominator;
                int numA = a.numerator * b.denominator;
                int numB = b.numerator * a.denominator;

                return ToString(numA + numB, closestDen);
            }
        }
        public static Fraction operator !(Fraction a)
        {
            Fraction temp = new Fraction(a.denominator, a.numerator);
            return temp;
        }
        public static string operator *(Fraction a, Fraction b)
        {
            int numResult = a.numerator * b.numerator;
            int denResult = a.denominator * b.denominator;
            return ToString(numResult, denResult);

        }
        public static string operator /(Fraction a, Fraction b)
        {

            int numResult = a.numerator * b.denominator;
            int denResult = a.denominator * b.numerator;
            return ToString(numResult, denResult);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            string[] first = Simplify(a.numerator, a.denominator);
            string[] second = Simplify(b.numerator, b.denominator);
            if (first[0].Equals(second[0]) && first[1].Equals(second[1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            string[] first = Simplify(a.numerator, a.denominator);
            string[] second = Simplify(b.numerator, b.denominator);
            if (!first[0].Equals(second[0]) && !first[1].Equals(second[1]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string ToString(int a, int b)
        {


            if (a < 0 && b > 0 || a > 0 && b < 0)
            {
                a = Math.Abs(a);
                b = Math.Abs(b);
                string[] result = Simplify(a, b);
                return "-" + result[0] + "/" + result[1];
            }
            else
            {
                string[] result = Simplify(a, b);
                return result[0] + "/" + result[1];
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Fraction fraction &&
                   numerator == fraction.numerator &&
                   denominator == fraction.denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }
    }
    private class Test
    {
        const string test;
        readonly string test1;
    }
    class Program
    {
        static void Main(string[] args)
        {



        }
    }
}
