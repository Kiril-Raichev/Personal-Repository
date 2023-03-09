using DI.Triangle.Models;
namespace DI.Triangle.Services.Interfaces
{
    public interface ITriangleMethods
    {
        public double Area(double a, double b, double c);
        public double Perimeter(double a, double b, double c);
        public bool IsRightAngled(double a, double b, double c);
        public bool IsEqualiteral(double a, double b, double c);
        public bool IsIsosceles(double a, double b, double c);
        public bool AreTrianglesCongruent(double a, double b, double c,TriangleInstance congruentTriangle);
    }
}
