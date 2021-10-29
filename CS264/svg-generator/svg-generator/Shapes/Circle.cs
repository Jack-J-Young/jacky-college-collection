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
            UpdateValues();
        }

        public override void UpdateValues()
        {
            UpdateCX();
            UpdateCY();
            UpdateR();
        }

        public override void UpdateWithUI()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("0 - edit cx");
                Console.WriteLine("1 - edit cy");
                Console.WriteLine("2 - edit r");
                Console.WriteLine("3 - edit fill");
                Console.WriteLine("4 - edit stroke");
                Console.WriteLine("5 - edit stroke width");
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
                        UpdateR();
                        break;
                    case '3':
                        UpdateFill();
                        break;
                    case '4':
                        UpdateStroke();
                        break;
                    case '5':
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

        public void UpdateR()
        {
            r = (int)UserInput("Input Radius: ", 0);
        }

        public override string GetTag()
        {
            return $"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{r}\" stroke=\"#{stroke}\" fill=\"#{fill}\" stroke-width={stroke_width}px />";
        }
    }
}
