using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator.Shapes.Impl
{
    class Rectangle : Shape
    {
        public override string Name => "Rectangulo";

        public override double GetArea()
        {
            int width = Point2.X - Point1.X,
                height = Point2.Y - Point1.Y;

            return width * height;
        }
    }
}
