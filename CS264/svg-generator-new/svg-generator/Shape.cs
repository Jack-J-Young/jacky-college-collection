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
            fill = RandomColour();
        }

        public void UpdateStroke()
        {
            Random rand = new Random();
            stroke = RandomColour();
        }

        public void StrokeWidth()
        {
            Random rand = new Random();
            stroke_width = rand.Next(0,4);
        }

        // static method for forcing a valid user input for different value types
        private static string RandomColour()
        {
            Random rand = new Random();
            string output = "";
            for (int i = 0; i < 6; i++)
            {
                int next = rand.Next(0, 16);
                output += (next < 10) ? next + "" : ((char)(next + 87)) + "";
            }
            return output;
        }

        // abstract methods for use in canvas object
        public abstract void UpdateValues();
        public abstract string GetTag();
    }
}
