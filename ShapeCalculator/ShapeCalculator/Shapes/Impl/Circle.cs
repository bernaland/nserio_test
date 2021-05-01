using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator.Shapes.Impl
{
    class Circle : Shape
    {
        public override string Name => "Circulo";

        public override double GetArea()
        {
            int width = Point2.X - Point1.X,
                height = Point2.Y - Point1.Y;

            //Geometricamente el radio de la circunferencia con centro en Point1 y extremo en Point2 es
            //r = sqrt((x2 - x1)^2 + (y2 - y1)^2)
            double radius = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

            return Math.PI + Math.Pow(radius, 2);
        }
    }
}
