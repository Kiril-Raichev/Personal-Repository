using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleTask;
using FluentAssertions;
using System;

namespace TriangleTaskTestFluent
{
    [TestClass]
    public class TriangleTestFluent
    {
        [TestMethod]
        public void Triangle_CreateTriangle_ThrowsException()
        {
            Action triangle = () => { new Triangle(1, 9, 16); };

            triangle.Should().Throw<Exception>();
        }
        [TestMethod]
        public void Area_CalculatesArea_ReturnsCorrectArea()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            triangle.Area().Should().BeApproximately(6, 0.001);
        }
        //[TestMethod]
        //public void Area_CalculatesArea_ReturnsWrongArea()
        //{
        //    Triangle triangle = new Triangle(3, 4, 5);
        //    triangle.Area().Should().NotBeApproximately(6, 0.001);
        //}
        [TestMethod]
        public void Perimeter_CalculatesPerimeter_ReturnsCorrectPerimeter()
        {
            Triangle triangle = new Triangle(3, 4, 5);

            triangle.Perimeter().Should().BeApproximately(12, 0.001);
        }
        //[TestMethod]
        //public void Perimeter_CalculatesPerimeter_ReturnsWrongPerimeter()
        //{
        //    Triangle triangle = new Triangle(3, 4, 5);
        //
        //    triangle.Perimeter().Should().NotBeApproximately(12, 0.001);
        //}
        [TestMethod]
        public void IsRightAngled_IsTriangleRightAngled_ReturnTrue()
        {
            Triangle triangle = new Triangle(3, 4, 5);

            triangle.IsRightAngled().Should().BeTrue();
        }
        [TestMethod]
        public void IsRightAngled_IsTriangleRightAngled_ReturnFalse()
        {
            Triangle triangle = new Triangle(3, 4, 6);

            triangle.IsRightAngled().Should().BeFalse();

        }
        [TestMethod]
        public void IsEqualiteral_IsTriangleEqualiteral_ReturnTrue()
        {
            Triangle triangle = new Triangle(3, 3, 3);

            triangle.IsEqualiteral().Should().BeTrue();

        }
        [TestMethod]
        public void IsEqualiteral_IsTriangleEqualiteral_ReturnFalse()
        {
            Triangle triangle = new Triangle(3, 3, 4);

            triangle.IsEqualiteral().Should().BeFalse();

        }
        [TestMethod]
        public void IsIsosceles_IsTriangleIsosceles_ReturnTrue()
        {
            Triangle triangle = new Triangle(3, 3, 4);

            triangle.IsIsosceles().Should().BeTrue();

        }
        [TestMethod]
        public void IsIsosceles_IsTriangleIsosceles_ReturnFalse()
        {
            Triangle triangle = new Triangle(3, 5, 4);

            triangle.IsIsosceles().Should().BeFalse();

        }
        [TestMethod]
        public void IsCongruent_AreTwoTrianglesCongruent_ReturnTrue()
        {
            Triangle triangle = new Triangle(3, 5, 4);
            Triangle congruentTriangle = new Triangle(4, 3, 5);

            triangle.IsCongruent(congruentTriangle).Should().BeTrue();

        }
        [TestMethod]
        public void IsCongruent_AreTwoTrianglesCongruent_ReturnFalse()
        {
            Triangle triangle = new Triangle(3, 5, 6);
            Triangle congruentTriangle = new Triangle(3, 5, 4);

            triangle.IsCongruent(congruentTriangle).Should().BeFalse();

        }
    }
}
