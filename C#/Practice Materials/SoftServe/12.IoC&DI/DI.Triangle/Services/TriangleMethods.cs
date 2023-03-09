using System;
using System.Collections.Generic;
using System.Linq;
using DI.Triangle.Services.Interfaces;
using DI.Triangle.Models;

namespace DI.Triangle.Services
{
    public class TriangleMethods : ITriangleMethods
    {
        public double Area(double a, double b, double c)
        {
            var semip = Perimeter(a, b, c) / 2;
            return Math.Sqrt((semip * (semip - a) * (semip - b) * (semip - c)));
        }
        public double Perimeter(double a, double b, double c)
        {
            return (a + b + c);

        }
        public bool IsRightAngled(double a, double b, double c)
        {
            if ((Math.Pow(a, 2) + Math.Pow(b, 2)) != Math.Pow(c, 2))
            {
                return false;
            }
            return true;
        }
        public bool IsEqualiteral(double a, double b, double c)
        {
            double[] sides = new double[] { a, b, c };
            int NumOfDifferentSides()
            {
                return sides.Distinct<double>().Count();
            }
            if (NumOfDifferentSides() != 1)
            {
                return false;
            }
            return true;
        }
        public bool IsIsosceles(double a, double b, double c)
        {
            double[] sides = new double[] { a, b, c };
            int NumOfDifferentSides()
            {
                return sides.Distinct<double>().Count();
            }
            if (NumOfDifferentSides() != 2)
            {
                return false;
            }
            return true;
        }
        public bool AreTrianglesCongruent(double a,double b,double c, TriangleInstance congruentTriangle)
        {
            var triangleSides = new List<double> { a, b, c};
            var congruentTriangleSides = new List<double> { congruentTriangle.Sides[0], congruentTriangle.Sides[1], congruentTriangle.Sides[2] };
            var numOfSameSides = triangleSides.ToList().Where(congruentTriangleSides.Remove).ToList();
            if (numOfSameSides.Count() != 3)
            {
                return false;
            }
            return true;
        }
    }
}
