using svg_generator.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Polyline : Shape
    {
        public List<Point> points;

        public Polyline()
        {
            UpdateValues();
        }

        public override void UpdateValues()
        {
            UpdatePoints();
        }

        public override void UpdateWithUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - edit point");
                Console.WriteLine("1 - edit stroke");
                Console.WriteLine("2 - edit stroke width");
                Console.WriteLine();
                Console.WriteLine("c - cancel");
                Console.WriteLine();

                char command = Console.ReadKey().KeyChar;

                switch (command)
                {
                    case '0':
                        UpdatePoints();
                        break;
                    case '1':
                        UpdateStroke();
                        break;
                    case '2':
                        UpdateStroke();
                        break;
                    case 'c':
                        return;
                    default:
                        break;
                }
            }
        }

        public void UpdatePoints()
        {
            Console.Clear();
            points = new List<Point>();
            string input;
            do
            {
                Point p = new Point();
                while (true)
                {
                    Console.Write($"Input X or q to quit: ");
                    input = Console.ReadLine();
                    try
                    {
                        if (input == "q")
                            break;
                        p.x = Int32.Parse(input);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid");
                    }
                }

                if (input == "q")
                    break;
                while (true)
                {
                    Console.Write($"Input Y: ");
                    input = Console.ReadLine();
                    try
                    {
                        p.y = Int32.Parse(input);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                points.Add(p);
            } while (input != "q");
        }

        public override string GetTag()
        {
            String output = "";
            for (int i = 0; i < points.Count; i++)
                output += $"{points[i].ToPoint()} ";
            return $"<polyline points=\"{output}\" stroke=\"#{stroke}\" stroke-width={stroke_width}px />";
        }
    }
}
