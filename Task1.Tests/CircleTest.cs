using Task1.Abstarct;
using Xunit;

namespace Task1.Tests
{
    public class CircleTest
    {
        /// <summary>
        /// Validate that area calculation is correct
        /// </summary>
        [Theory]
        [InlineData(7.2)]
        public void CalculatePlaneAreaTest(double radius)
        {
            // Arrange
            AShape shape = new Circle(radius);

            // Act
            var result = shape.CalculatePlaneArea();

            // Assert
            Assert.Equal(Math.PI * Math.Pow(radius, 2), result);
        }

        /// <summary>
        /// Validate that if radius out of bound exception throws
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(-4.7)]
        public void RadiusOutOfBoundsTest(double radius)
        {
            // Arrange
            AShape shape = new Circle(7);

            // Act
            Action act = () => ((Circle)shape).Radius = radius;

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Radius of a circle can't be less or equal 0 (Parameter 'Radius')", exception.Message);
        }
    }
}
