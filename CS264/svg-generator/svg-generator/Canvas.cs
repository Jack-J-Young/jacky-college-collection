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
                default:
                    break;
            }
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
