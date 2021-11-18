using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Line : Shape
    {
        public int x1, y1, x2, y2;

        public Line()
        {
            UpdateValues();
        }

        public override void UpdateValues()
        {
            Random rand = new Random();
            UpdateX1(rand.Next(0, 500));
            UpdateY1(rand.Next(0, 500));
            UpdateX2(rand.Next(0, 500));
            UpdateY2(rand.Next(0, 500));
        }

        public void UpdateX1(int x1)
        {
            this.x1 = x1;
        }

        public void UpdateY1(int y1)
        {
            this.y1 = y1;
        }

        public void UpdateX2(int x2)
        {
            this.x2 = x2;
        }

        public void UpdateY2(int y2)
        {
            this.y2 = y2;
        }

        public override string GetTag()
        {
            return $"<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" stroke=\"#{stroke}\" stroke-width=\"{stroke_width}\" />";
        }
    }
}
