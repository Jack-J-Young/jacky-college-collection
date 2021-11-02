using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Rectangle : Shape
    {
        public int x, y, width, height;

        public Rectangle()
        {
            UpdateValues();
        }

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override void UpdateValues()
        {
            UpdateX();
            UpdateY();
            UpdateWidth();
            UpdateHeight();
        }

        public override void UpdateWithUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - edit x");
                Console.WriteLine("1 - edit y");
                Console.WriteLine("2 - edit width");
                Console.WriteLine("3 - edit height");
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
                        UpdateX();
                        break;
                    case '1':
                        UpdateY();
                        break;
                    case '2':
                        UpdateWidth();
                        break;
                    case '3':
                        UpdateHeight();
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

        public void UpdateX()
        {
            x = (int)UserInput("Input X: ", 0);
        }

        public void UpdateY()
        {
            y = (int)UserInput("Input Y: ", 0);
        }

        public void UpdateWidth()
        {
            width = (int)UserInput("Input width: ", 0);
        }

        public void UpdateHeight()
        {
            height = (int)UserInput("Input height: ", 0);
        }

        public override string GetTag()
        {
            return $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" rx=\"{0}\" ry=\"{0}\" stroke=\"#{stroke}\" fill=\"#{fill}\" stroke-width={stroke_width}px />";
        }
    }
}
