using System;
using DI.Web.Controllers;
using DI.Web.Services.Interfaces;
using DI.Web.Services;
using DI.Triangle.Services.Interfaces;
using DI.Triangle.Services;
using DI.Triangle.Models;
namespace DI.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Console.WriteLine("Task 1:");
            ICookware stove = new Stove();
            ICookware oven = new Oven();
            Cook cook = new Cook();
            cook.Cooking(stove);
            cook.Cooking(oven);

            //Task 2
            //Console.WriteLine("Task 2:");
            //ICookwareService ovenS = new OvenService();
            //ICookwareService stoveS = new StoveService();
            //ICookService cookS = new CookService(ovenS, stoveS);
            //CookController controller = new CookController(cookS);
            //controller.Cooking();

            //Task 3 and 4
            ITriangleMethodsBool triangleMethodsBool = new TriangleMethods();
            ITriangleMethodsDouble triangleMethodsDouble = new TriangleMethodsDouble();
            TriangleInstance triangle = new TriangleInstance(triangleMethodsBool,triangleMethodsDouble, 3,4,5);

            Console.WriteLine($"Triangle with sides: {3} {4} {5} has:");
            Console.WriteLine($"Area : {triangle.Area()}");
            Console.WriteLine($"Perimeter : {triangle.Perimeter()}");
            Console.WriteLine($"Is right angled : {triangle.IsRightAngled()}");
            Console.WriteLine($"Triangle with sides : {3} {3} {3} :");
            TriangleInstance triangleEquiliteral = new TriangleInstance(triangleMethodsBool, triangleMethodsDouble, 3, 3, 3);
            Console.WriteLine($"Is Equiliteral : {triangleEquiliteral.IsEqualiteral()}");
            Console.WriteLine($"Triangle with sides : {3} {4} {3} :");
            TriangleInstance triangleIsosceles = new TriangleInstance(triangleMethodsBool, triangleMethodsDouble, 3, 4, 3);
            Console.WriteLine($"Is Isosceles : {triangleIsosceles.IsIsosceles()}");
            TriangleInstance triangleCongruent = new TriangleInstance(triangleMethodsBool, triangleMethodsDouble, 3, 4, 5);
            Console.WriteLine($"Triangle with sides : {3} {4} {5} and Triangle with sides : {4} {5} {3}");
            Console.WriteLine($"Are congruent : {triangle.AreTrianglesCongruent(triangleCongruent)}");
        }
    }
}
