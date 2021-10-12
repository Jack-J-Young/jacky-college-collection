using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Rectangle : Shape
    {
        public int x, y, width, height;

        public Rectangle()
        {
            Console.Write("Input X: ");
            x = Int32.Parse(Console.ReadLine());
            Console.Write("Input Y: ");
            y = Int32.Parse(Console.ReadLine());
            Console.Write("Input Width: ");
            width = Int32.Parse(Console.ReadLine());
            Console.Write("Input Height: ");
            height = Int32.Parse(Console.ReadLine());
        }

        public override string GetTag()
        {
            return $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" rx=\"{0}\" ry=\"{0}\" />";
        }
    }
}
