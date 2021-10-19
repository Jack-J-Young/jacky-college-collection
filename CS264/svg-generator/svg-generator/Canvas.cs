using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Canvas
    {
        private List<Shape> shapes;

        public Canvas()
        {
            shapes = new List<Shape>();
        }

        public void AddShape(int type)
        {
            switch (type)
            {
                case 0:
                    shapes.Add(new Rectangle());
                    break;
                case 1:
                    shapes.Add(new Circle());
                    break;
                case 2:
                    shapes.Add(new Ellipse());
                    break;
                case 3:
                    shapes.Add(new Line());
                    break;
                case 4:
                    shapes.Add(new Polyline());
                    break;
                case 5:
                    shapes.Add(new Polygon());
                    break;
                case 6:
                    shapes.Add(new Path());
                    break;
                default:
                    break;
            }
        }

        public void AddShape()
        {
            Console.Clear();
            Console.WriteLine("Press key to create shape");
            Console.WriteLine("0 - Rectangle");
            Console.WriteLine("1 - Circle");
            Console.WriteLine("2 - Ellipse");
            Console.WriteLine("3 - Line");
            Console.WriteLine("4 - Polyline");
            Console.WriteLine("5 - Polygon");
            Console.WriteLine("6 - Path");
            Console.WriteLine("");
            Console.WriteLine("q - quit");
            char input = Console.ReadKey().KeyChar;
            if (input == 'q')
                return;
            if ((int)input >= 48 && (int)input <= 54)
                AddShape(input - 48);
            else
                AddShape();
        }

        public void GetSVG()
        {
            string output = "";
            foreach (Shape s in shapes)
                output += $"{s.GetTag()}\n";
            Console.WriteLine(output);
        }
    }
}
