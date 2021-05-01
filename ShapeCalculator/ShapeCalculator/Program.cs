using ShapeCalculator.Shapes;
using ShapeCalculator.Shapes.Impl;
using System;
using static System.Console;

namespace ShapeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string shapeType = GetShapeType();

            try
            {
                
                Shape selectedShape = null;

                if ("A".Equals(shapeType, StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedShape = new Rectangle();
                }
                else if ("B".Equals(shapeType, StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedShape = new Circle();
                }
                else
                {
                    WriteLine("Debe seleccionar una opción valida!");
                    return;
                }
                selectedShape.Point1 = new System.Drawing.Point(GetCoordinateValue("X", "1"), GetCoordinateValue("Y", "1"));
                selectedShape.Point2 = new System.Drawing.Point(GetCoordinateValue("X", "2"), GetCoordinateValue("Y", "2"));

                WriteLine($"El área del {selectedShape.Name} es {selectedShape.GetArea():0.00##}");
            }
            catch (Exception ex)
            {
                WriteLine("Ha ocurrido un error y no se puede realizar el calculo del área de la figura");
#if DEBUG
                WriteLine(ex.Message);
                WriteLine(ex.StackTrace);
#endif
            }
        }

        private static int GetCoordinateValue(string coordinate, string pointName)
        {
            WriteLine($"Indique la coordenada {coordinate} del punto {pointName}");
            return (int)double.Parse(ReadLine());
        }

        private static string GetShapeType()
        {
            WriteLine("Indique el tipo de figura y presione Enter para continuar");
            WriteLine("A) Rectangulo");
            WriteLine("B) Circulo");
            string shapeType = ReadLine();
            return shapeType;
        }
    }
}
