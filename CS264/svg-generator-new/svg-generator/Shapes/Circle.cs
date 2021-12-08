using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
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
            Random rand = new Random();
            UpdateCX(rand.Next(0, 500));
            UpdateCY(rand.Next(0, 500));
            UpdateR(rand.Next(2, 50));
        }

        public void UpdateCX(int cx)
        {
            this.cx = cx;
        }

        public void UpdateCY(int cy)
        {
            this.cy = cy;
        }

        public void UpdateR(int r)
        {
            this.r = r;
        }

        public override string GetTag()
        {
            return $"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{r}\" stroke=\"#{stroke}\" fill=\"#{fill}\" stroke-width=\"{stroke_width}\" />";
        }
    }
}
