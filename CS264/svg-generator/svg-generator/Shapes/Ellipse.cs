using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Ellipse : Shape
    {
        public int cx, cy, rx, ry;

        public Ellipse()
        {
            UpdateValues();
        }

        public override void UpdateValues()
        {
            UpdateCX();
            UpdateCY();
            UpdateRX();
            UpdateRY();
        }

        public override void UpdateWithUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - edit cx");
                Console.WriteLine("1 - edit cy");
                Console.WriteLine("2 - edit rx");
                Console.WriteLine("3 - edit ry");
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
                        UpdateCX();
                        break;
                    case '1':
                        UpdateCY();
                        break;
                    case '2':
                        UpdateRX();
                        break;
                    case '3':
                        UpdateRY();
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

        public void UpdateCX()
        {
            cx = (int)UserInput("Input X: ", 0);
        }

        public void UpdateCY()
        {
            cy = (int)UserInput("Input Y: ", 0);
        }

        public void UpdateRX()
        {
            rx = (int)UserInput("Input Rx: ", 0);
        }

        public void UpdateRY()
        {
            ry = (int)UserInput("Input Ry: ", 0);
        }

        public override string GetTag()
        {
            return $"<ellipse cx=\"{cx}\" cy=\"{cy}\" rx=\"{rx}\" ry=\"{ry}\" stroke=\"#{stroke}\" fill=\"#{fill}\" stroke-width={stroke_width}px />";
        }
    }
}
