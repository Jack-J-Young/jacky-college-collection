using svg_generator.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Canvas
    {
        // shapes list, index = z value
        public List<Shape> shapes;

        public Canvas()
        {
            shapes = new List<Shape>();
        }

        public bool AddShape(string inp)
        {
            switch (inp.ToLower())
            {
                case "rectangle":
                    shapes.Add(new Rectangle());
                    return true;
                case "circle":
                    shapes.Add(new Circle());
                    return true;
                case "ellipse":
                    shapes.Add(new Ellipse());
                    return true;
                case "line":
                    shapes.Add(new Line());
                    return true;
                default:
                    Console.WriteLine("Invalid shape");
                    return false;
            }
        }

        private void AddShape(int type)
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

        public void clear()
        {
            shapes = new List<Shape>();
        }

        public void GetSVG()
        {
            Console.Clear();
            string output = "<svg>\n";
            foreach (Shape s in shapes)
                output += $"{s.GetTag()}\n";
            output += "</svg>";
            Console.WriteLine(output);

            // save file
            File.WriteAllText("output.svg", output);

            Console.WriteLine();
            Console.WriteLine("File saved as output.svg");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
