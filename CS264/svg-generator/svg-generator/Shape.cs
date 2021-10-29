using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace svg_generator
{
    // Abstract shape class for canvas and grouping
    abstract class Shape
    {
        // all shapes have default styling (fill is unused for line and polyline)
        public string fill = "FFFFFF";
        public string stroke = "000000";
        public int stroke_width = 1;

        // ui update calsses for creating and edititing shapes (each shape also has updates for unique variables
        public void UpdateFill()
        {
            fill = (string)UserInput("Input Fill (Hexadecimal): ", 1);
        }

        public void UpdateStroke()
        {
            stroke = (string)UserInput("Input Stroke (Hexadecimal): ", 1);
        }

        public void StrokeWidth()
        {
            stroke_width = (int)UserInput("Input X: ", 0);
        }

        // static method for forcing a valid user input for different value types
        public static object UserInput(string message, int type)
        {
            // look until a return from a valid input
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write(message);

                    switch (type)
                    {
                        // int
                        case 0:
                            return Int32.Parse(Console.ReadLine());
                        // hexadecial as string
                        case 1:
                            string i = Console.ReadLine().ToUpper();
                            Regex r = new Regex("[0-9A-F]{6}");
                            if (r.IsMatch(i))
                                return i;
                            break;
                        default:
                            return null;
                    }
                }
                catch (Exception) { }
            }
        }

        // abstract methods for use in canvas object
        public abstract void UpdateValues();
        public abstract void UpdateWithUI();
        public abstract string GetTag();
    }
}
