using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator.Shapes
{
    abstract class Shape
    {
        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public abstract double GetArea();

        public abstract string Name { get; }
    }
}
