using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Line : Shape
    {
        public int x1, y1, x2, y2;

        public Line()
        {
            Console.Write("Input X1: ");
            x1 = Int32.Parse(Console.ReadLine());
            Console.Write("Input Y1: ");
            y1 = Int32.Parse(Console.ReadLine());
            Console.Write("Input X2: ");
            x2 = Int32.Parse(Console.ReadLine());
            Console.Write("Input Y2: ");
            y2 = Int32.Parse(Console.ReadLine());
        }

        public override string GetTag()
        {
            return $"<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" />";
        }
    }
}
