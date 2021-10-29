using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Line : Shape
    {
        public int x1, y1, x2, y2;

        public Line()
        {
            UpdateValues();
        }

        public override void UpdateValues()
        {
            UpdateX1();
            UpdateY1();
            UpdateX2();
            UpdateY2();
        }

        public override void UpdateWithUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - edit x1");
                Console.WriteLine("1 - edit y1");
                Console.WriteLine("2 - edit x2");
                Console.WriteLine("3 - edit y2");
                Console.WriteLine("4 - edit fill");
                Console.WriteLine("5 - edit stroke");
                Console.WriteLine("6 - edit stroke width");
                Console.WriteLine();
                Console.WriteLine("c - cancel");
                Console.WriteLine();

                char command = Console.ReadKey().KeyChar;

                switch (command)
                {
                    case '0':
                        UpdateX1();
                        break;
                    case '1':
                        UpdateY1();
                        break;
                    case '2':
                        UpdateX2();
                        break;
                    case '3':
                        UpdateY2();
                        break;
                    case '4':
                        UpdateFill();
                        break;
                    case '5':
                        UpdateStroke();
                        break;
                    case '6':
                        UpdateStroke();
                        break;
                    case 'c':
                        return;
                    default:
                        break;
                }
            }
        }

        public void UpdateX1()
        {
            x1 = (int)UserInput("Input X1: ", 0);
        }

        public void UpdateY1()
        {
            y1 = (int)UserInput("Input Y1: ", 0);
        }

        public void UpdateX2()
        {
            x1 = (int)UserInput("Input X1: ", 0);
        }

        public void UpdateY2()
        {
            y1 = (int)UserInput("Input Y1: ", 0);
        }

        public override string GetTag()
        {
            return $"<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" stroke=\"#{stroke}\" stroke-width={stroke_width}px />";
        }
    }
}
