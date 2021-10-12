using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Ellipse : Shape
    {
        public int cx, cy, rx, ry;

        public Ellipse()
        {
            Console.Write("Input X: ");
            cx = Int32.Parse(Console.ReadLine());
            Console.Write("Input Y: ");
            cy = Int32.Parse(Console.ReadLine());
            Console.Write("Input Rx: ");
            rx = Int32.Parse(Console.ReadLine());
            Console.Write("Input Ry: ");
            ry = Int32.Parse(Console.ReadLine());
        }

        public override string GetTag()
        {
            return $"<ellipse cx=\"{cx}\" cy=\"{cy}\" rx=\"{rx}\" ry=\"{ry}\" />";
        }
    }
}
