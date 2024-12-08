using Xunit;
using System;
using Shapes;

namespace Tests
{
    public class CircleTests
    {
        [Fact]
        public void Circle_CalculateArea_ValidRadius_ReturnsCorrectArea()
        {
            // Arrange
            double radius = 5;
            IShape circle = ShapeFactory.CreateCircle(radius);

            // Act
            double area = circle.CalculateArea();

            // Assert
            double expectedArea = Math.PI * Math.Pow(radius, 2);
            Assert.Equal(expectedArea, area, precision: 6);
        }

        [Fact]
        public void Circle_InvalidRadius_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateCircle(0));
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateCircle(-5));
        }
    }

    public class TriangleTests
    {
        [Fact]
        public void Triangle_CalculateArea_ValidSides_ReturnsCorrectArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            IShape triangle = ShapeFactory.CreateTriangle(sideA, sideB, sideC);

            // Act
            double area = triangle.CalculateArea();

            // Assert
            double expectedArea = 6;
            Assert.Equal(expectedArea, area, precision: 6);
        }

        [Fact]
        public void Triangle_InvalidSides_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTriangle(1, 2, 10)); // Invalid triangle
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTriangle(-1, 2, 3)); // Negative side length
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTriangle(0, 2, 3)); // Zero side length
        }

        [Fact]
        public void Triangle_IsRightTriangle_ValidRightTriangle_ReturnsTrue()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            var triangle = (Triangle)ShapeFactory.CreateTriangle(sideA, sideB, sideC);
            
            bool isRightTriangle = triangle.IsRightTriangle();
            
            Assert.True(isRightTriangle);
        }

        [Fact]
        public void Triangle_IsRightTriangle_InvalidTriangle_ReturnsFalse()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 6;
            var triangle = (Triangle)ShapeFactory.CreateTriangle(sideA, sideB, sideC);

            // Act
            bool isRightTriangle = triangle.IsRightTriangle();

            // Assert
            Assert.False(isRightTriangle);
        }
    }
}
