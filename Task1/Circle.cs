using Task1.Abstarct;

namespace Task1
{
    public class Circle : AShape
    {
        private double _radius;

        /// <summary>
        /// Gets or sets raduis parameter with validation
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius of a circle can't be less or equal 0", nameof(Radius));
                }
                _radius = value;
            }
        }

        /// <summary>
        /// Create circle shape object
        /// </summary>
        /// <param name="radius">Sets radius parameter</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculatePlaneArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
