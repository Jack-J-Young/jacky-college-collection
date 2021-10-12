using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Canvas c = new Canvas();

            c.AddShape(0);

            c.AddShape(1);

            c.AddShape(2);

            c.AddShape(3);

            c.GetSVG();

            Console.ReadKey();
        }
    }
}
