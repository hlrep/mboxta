using Task1.Abstarct;
using Xunit;

namespace Task1.Tests
{
    public class TriangleTest
    {
        /// <summary>
        /// Validate that area calculation is correct
        /// </summary>
        [Theory]
        [InlineData(10, 24, 26)]
        public void CalculatePlaneAreaTest(double a, double b, double c)
        {
            // Arrange
            AShape shape = new Triangle(a, b, c);

            // Act
            var result = shape.CalculatePlaneArea();

            // Assert
            var perimeter = a + b + c;
            Assert.Equal(Math.Sqrt(perimeter) * (perimeter - a) * (perimeter - b) * (perimeter - c), result);
        }

        /// <summary>
        /// Validate that right triangle check is correct
        /// </summary>
        [Theory]
        [InlineData(10, 24, 26, null, true)]
        [InlineData(10, 24, 26, 1E-11, true)]
        [InlineData(13, 14, 15, null, false)]
        public void IsRightTriangleTest(double a, double b, double c, double? precision, bool expected)
        {
            // Arrange
            AShape shape = new Triangle(a, b, c);

            // Act
            var result = precision.HasValue ? ((Triangle)shape).IsRightTriangle(precision.Value) : ((Triangle)shape).IsRightTriangle();

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Validate that if sides bound exceptions throws
        /// </summary>
        [Theory]
        [InlineData(1, 2, 4, null, "Triangle with current parameters doesn't exists (Parameter 'Sides')")]
        [InlineData(10, 24, 26, (double)15, "Triangle should have exactly 3 sides (Parameter 'Sides')")]
        [InlineData(10, -7, 26, null, "Triangle's sides can't be less or equal 0 (Parameter 'Sides')")]
        public void TriangleExceptionsTest(double a, double b, double c, double? d, string exceptionMessage)
        {
            // Arrange
            AShape shape = new Triangle(10, 24, 26);

            // Act
            Action act = () => {
                if (d.HasValue)
                {
                    ((Triangle)shape).Sides = new double[] { a, b, c, d.Value };
                }
                else
                {
                    ((Triangle)shape).Sides = new double[] { a, b, c };
                }
            };

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}
