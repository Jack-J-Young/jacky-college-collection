using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace svg_generator
{
    abstract class Shape
    {
        public string fill = "FFFFFF";
        public string stroke = "000000";
        public int stroke_width = 1;

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

        public object UserInput(string message, int type)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write(message);
                    switch (type)
                    {
                        case 0:
                            return Int32.Parse(Console.ReadLine());
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

        public abstract void UpdateValues();
        public abstract void UpdateWithUI();
        public abstract string GetTag();
    }
}
