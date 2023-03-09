using System;
using System.Collections.Generic;
using System.Linq;
using DI.Triangle.Services.Interfaces;
namespace DI.Triangle.Models
{
    public class TriangleInstance
    {
        //fuse to one dependency
        private ITriangleMethods triangleMethods;
        double[] sides;
        public TriangleInstance(ITriangleMethods triangleMethods, double a, double b, double c)
        {
            this.triangleMethods = triangleMethods;
            sides = new double[] { a, b, c };
            sides.OrderBy(a => a);
            if ((a < 0 || b < 0 || c < 0) || (sides[0] + sides[1] < sides[2]))
            {
                throw new Exception("Invalid triangle side input");
            }
        }
        public List<double> Sides { get => sides.ToList(); }
        public double Area() => this.triangleMethods.Area(sides[0], sides[1], sides[2]);
        public double Perimeter() => this.triangleMethods.Perimeter(sides[0], sides[1], sides[2]);
        public bool IsRightAngled() => this.triangleMethods.IsRightAngled(sides[0], sides[1], sides[2]);
        public bool IsEqualiteral() => this.triangleMethods.IsEqualiteral(sides[0], sides[1], sides[2]);
        public bool IsIsosceles() => this.triangleMethods.IsIsosceles(sides[0], sides[1], sides[2]);
        public bool AreTrianglesCongruent(TriangleInstance congruentTriangle) => this.triangleMethods.AreTrianglesCongruent(sides[0], sides[1], sides[2], congruentTriangle);
    }
}
