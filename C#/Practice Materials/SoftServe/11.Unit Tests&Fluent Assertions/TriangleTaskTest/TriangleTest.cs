using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using TriangleTask;

namespace TriangleTaskTest
{

    [TestClass]
    public class TriangleTest
    {
        //Fix names name + scenario + result/AAA/add parameters/
        [DataRow(1, 9, 16)]
        [TestMethod]
        public void Triangle_CreateTriangle_ThrowsException(double a, double b, double c)
        {
            Assert.ThrowsException<Exception>(() => new Triangle(a, b, c));
        }

        [DataRow(3, 4, 5)]
        [TestMethod]
        public void Area_CalculatesArea_ReturnsCorrectArea(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            var semiPerimeter = triangle.Perimeter() / 2;
            double expected = Math.Sqrt((semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c)));

            double actual = triangle.Area();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 4, 7)]
        [TestMethod]
        public void Area_CalculatesArea_ReturnsFalseArea(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            double expected = 6;

            double actual = triangle.Area();

            Assert.AreNotEqual(actual, expected);
        }

        [DataRow(3, 4, 5)]
        [TestMethod]
        public void Perimeter_CalculatesPerimeter_ReturnsCorrectPerimeter(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            double expected = 12;

            double actual = triangle.Perimeter();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 4, 7)]
        [TestMethod]
        public void Perimeter_CalculatesPerimeter_ReturnsFalsePerimeter(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            double expected = 12;

            double actual = triangle.Perimeter();

            Assert.AreNotEqual(actual, expected);
        }

        [DataRow(3, 4, 5)]
        [TestMethod]
        public void IsRightAngled_IsTriangleRightAngled_ReturnTrue(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool expected = true;

            bool actual = triangle.IsRightAngled();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 4, 6)]
        [TestMethod]
        public void IsRightAngled_IsTriangleRightAngled_ReturnFalse(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool expected = false;

            bool actual = triangle.IsRightAngled();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 3, 3)]
        [TestMethod]
        public void IsEqualiteral_IsTriangleEqualiteral_ReturnTrue(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool expected = true;

            bool actual = triangle.IsEqualiteral();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 3, 4)]
        [TestMethod]
        public void IsEqualiteral_IsTriangleEqualiteral_ReturnFalse(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool expected = false;

            bool actual = triangle.IsEqualiteral();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 3, 4)]
        [TestMethod]
        public void IsIsosceles_IsTriangleIsosceles_ReturnTrue(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool expected = true;

            bool actual = triangle.IsIsosceles();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 5, 4)]
        [TestMethod]
        public void IsIsosceles_IsTriangleIsosceles_ReturnFalse(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool expected = false;

            bool actual = triangle.IsIsosceles();

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 5, 4, 4, 3, 5)]
        [TestMethod]
        public void IsCongruent_AreTwoTrianglesCongruent_ReturnTrue(double a, double b, double c, double aa, double bb, double cc)
        {
            Triangle triangle = new Triangle(a, b, c);
            Triangle congruentTriangle = new Triangle(aa, bb, cc);
            bool expected = true;

            bool actual = triangle.IsCongruent(congruentTriangle);

            Assert.AreEqual(actual, expected);
        }

        [DataRow(3, 5, 6, 3, 5, 4)]
        [TestMethod]
        public void IsCongruent_AreTwoTrianglesCongruent_ReturnFalse(double a, double b, double c, double aa, double bb, double cc)
        {
            Triangle triangle = new Triangle(a, b, c);
            Triangle congruentTriangle = new Triangle(aa, bb, cc);
            bool expected = false;

            bool actual = triangle.IsCongruent(congruentTriangle);

            Assert.AreEqual(actual, expected);
        }
    }
}
