using svg_generator.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace svg_generator
{
    class Path : Shape
    {
        public List<Point> points;

        public Path()
        {
            points = new List<Point>();
            string input;
            Regex types = new Regex("^[MmLlHhVvZz]?$");
            do
            {
                Console.Write($"Input Type (MmLlHhVvZz) or q to quit: ");
                input = Console.ReadLine();
                if (input == "q")
                    break;
                if (types.IsMatch(input))
                {
                    Point p = new Point(input);
                    while (true)
                    {
                        Console.Write($"Input X: ");
                        input = Console.ReadLine();
                        try
                        {
                            p.x = Int32.Parse(input);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid");
                        }
                    }

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
                }
                
            } while (input != "q");
        }

        public override string GetTag()
        {
            String output = "";
            for (int i = 0; i < points.Count; i++)
                output += $"{points[i].ToString()} ";
            return $"<path d=\"{output}\" />";
        }
    }
}
