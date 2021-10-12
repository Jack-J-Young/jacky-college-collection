using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Circle : Shape
    {
        public int cx, cy, r;

        public Circle()
        {
            Console.Write("Input X: ");
            cx = Int32.Parse(Console.ReadLine());
            Console.Write("Input Y: ");
            cy = Int32.Parse(Console.ReadLine());
            Console.Write("Input Radius: ");
            r = Int32.Parse(Console.ReadLine());
        }

        public override string GetTag()
        {
            return $"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{r}\" />";
        }
    }
}
