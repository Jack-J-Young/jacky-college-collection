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

            char command = ' ';
            while (command != 'q')
            {
                Console.Clear();
                Console.WriteLine("h - help");
                Console.WriteLine("a - Add new shape");
                Console.WriteLine("e - Edit shapes");
                Console.WriteLine("o - output");
                command = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (command)
                {
                    case 'h':
                        Console.Clear();
                        Console.WriteLine("Commands TODO");
                        Console.WriteLine("press any key to exit help");
                        Console.ReadKey();
                        break;
                    case 'a':
                        c.AddShape();
                        break;
                    default:
                        Console.Write("Press h for help or q to quit");
                        break;
                }
            }
            c.AddShape(5);

            c.GetSVG();

            Console.ReadKey();
        }
    }
}
