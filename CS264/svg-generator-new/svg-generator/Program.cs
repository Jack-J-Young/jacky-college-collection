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
            // create new canvas
            Canvas c = new Canvas();

            char command = ' ';
            while (command != 'q')
            {
                // print ui
                Console.Clear();
                Console.WriteLine("Console SVG editor");
                Console.WriteLine();
                Console.WriteLine("a - Add new shape");
                Console.WriteLine("e - Edit shapes");
                Console.WriteLine("d - delete shapes");
                Console.WriteLine("z - edit layers");
                Console.WriteLine("o - output");
                Console.WriteLine();
                Console.WriteLine("q - quit");

                command = Console.ReadKey().KeyChar;
                Console.WriteLine();

                // commands
                switch (command)
                {
                    case 'a':
                        c.AddShape();
                        break;
                    case 'e':
                        c.EditShape();
                        break;
                    case 'd':
                        c.DeleteShape();
                        break;
                    case 'z':
                        c.EditZ();
                        break;
                    case 'o':
                        c.GetSVG();
                        break;
                    case 'q':
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
