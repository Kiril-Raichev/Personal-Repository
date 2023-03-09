using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleTask
{
    public class Triangle
    {
        double[] sides;
        public Triangle(double a, double b, double c)
        {
            sides = new double[] { a, b, c };
            sides.OrderBy(a => a);
            if ((a < 0 || b < 0 || c < 0) || (sides[0] + sides[1] < sides[2]))
            {
                throw new Exception("Invalid triangle sides input");
            }
        }
        public List<double> Sides { get => sides.ToList(); }
        public double Area()
        {
            var semiPerimeter = this.Perimeter() / 2;
            return Math.Sqrt((semiPerimeter * (semiPerimeter - sides[0]) * (semiPerimeter - sides[1]) * (semiPerimeter - sides[2])));
        }
        public double Perimeter()
        {
            return (sides[0] + sides[1] + sides[2]);
        }
        public bool IsRightAngled()
        {
            if ((Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2)) != Math.Pow(sides[2], 2))
            {
                return false;
            }
            return true;
        }
        private int NumOfDifferentSides()
        {
            return sides.Distinct<double>().Count();
        }
        public bool IsEqualiteral()
        {
            if (NumOfDifferentSides() != 1)
            {
                return false;
            }
            return true;
        }
        public bool IsIsosceles()
        {
            if (NumOfDifferentSides() != 2)
            {
                return false;
            }
            return true;
        }
        public bool IsCongruent(Triangle triangleInput)
        {
            var inputTriangleSides = new List<double> { triangleInput.Sides[0], triangleInput.Sides[1], triangleInput.Sides[2] };
            var numOfSameSides = this.sides.ToList().Where(inputTriangleSides.Remove).ToList();
            if (numOfSameSides.Count() != 3)
            {
                return false;
            }
            return true;
        }
        static void Main()
        {
        }
    }
}
