using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Point
    {
        public string type;
        public int x, y;
        public Point()
        {
            this.type = "";
        }
        public Point(char type, int x, int y)
        {
            this.type = $"{type}";
            this.x = x;
            this.y = y;
        }

        public Point(string type)
        {
            if (type != "")
                this.type = $"{type.First()}";
            else
                this.type = type;
        }

        public override string ToString()
        {
            return $"{type}{x} {y}";
        }

        public string ToPoint()
        {
            return $"{x}, {y}";
        }
    }
}
