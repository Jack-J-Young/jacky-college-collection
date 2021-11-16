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
            Random rand = new Random();
            UpdateX(rand.Next(0, 500));
            UpdateY(rand.Next(0, 500));
            UpdateWidth(rand.Next(2, 50));
            UpdateHeight(rand.Next(2, 50));
        }

        public void UpdateX(int x)
        {
            this.x = x;
        }

        public void UpdateY(int y)
        {
            this.y = y;
        }

        public void UpdateWidth(int width)
        {
            this.width = width;
        }

        public void UpdateHeight(int height)
        {
            this.height = height;
        }

        public override string GetTag()
        {
            return $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" rx=\"{0}\" ry=\"{0}\" stroke=\"#{stroke}\" fill=\"#{fill}\" stroke-width={stroke_width}px />";
        }
    }
}
