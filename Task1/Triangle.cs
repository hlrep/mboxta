using Task1.Abstarct;

namespace Task1
{
    public class Triangle : AShape
    {
        private double[] _sides = new double[3];

        /// <summary>
        /// Gets or sets sides of triangle with validation
        /// </summary>
        public double[] Sides
        {
            get { return _sides; }
            set
            {
                if (value.Length != 3)
                {
                    throw new ArgumentException("Triangle should have exactly 3 sides", nameof(Sides));
                }
                if (value[0] <= 0 || value[1] <= 0 || value[2] <= 0)
                {
                    throw new ArgumentException("Triangle's sides can't be less or equal 0", nameof(Sides));
                }
                if (value[0] + value[1] <= value[2] ||
                    value[0] + value[2] <= value[1] ||
                    value[1] + value[2] <= value[0])
                {
                    throw new ArgumentException("Triangle with current parameters doesn't exists", nameof(Sides));
                }
                _sides = value;
            }
        }

        /// <summary>
        /// Create triangle shape object
        /// </summary>
        /// <param name="a">Set first side</param>
        /// <param name="b">Set second side</param>
        /// <param name="c">Set third side</param>
        public Triangle(double a, double b, double c)
        {
            Sides = new double[3] { a, b, c };
        }

        public override double CalculatePlaneArea()
        {
            var perimeter = Sides.Sum();
            return Math.Sqrt(perimeter) * (perimeter - Sides[0]) * (perimeter - Sides[1]) * (perimeter - Sides[2]);
        }

        /// <summary>
        /// Check is current triangle is right trangle
        /// </summary>
        /// <param name="precision">Set specific precision</param>
        /// <returns>Is the current triangle is right triangle</returns>
        public bool IsRightTriangle(double precision = 1E-9)
        {
            var maxSidePosition = 0;
            var legSquareSum = (double)0;

            for (int sidePosition = 1; sidePosition < Sides.Length; sidePosition++)
            {
                var currentSideSize = Sides[sidePosition];
                if (Sides[maxSidePosition] < Sides[sidePosition])
                {
                    legSquareSum += Math.Pow(Sides[maxSidePosition], 2);
                    maxSidePosition = sidePosition;
                }
                else
                {
                    legSquareSum += Math.Pow(Sides[sidePosition], 2);
                }
            }

            var hypotenusSquare = Math.Pow(Sides[maxSidePosition], 2);

            return Math.Abs(hypotenusSquare - legSquareSum) < precision;
        }
    }
}
