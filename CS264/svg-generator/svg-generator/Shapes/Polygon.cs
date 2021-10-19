using svg_generator.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace svg_generator
{
    class Polygon : Shape
    {
        public List<Point> points;

        public Polygon()
        {
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
            }while (input != "q");
        }

        public override string GetTag()
        {
            String output = "";
            for (int i = 0; i < points.Count; i++)
                output += $"{points[i].ToPoint()} ";
            return $"<polygon points=\"{output}\" />";
        }
    }
}
