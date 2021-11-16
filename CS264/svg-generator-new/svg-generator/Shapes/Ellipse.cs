using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Ellipse : Shape
    {
        public int cx, cy, rx, ry;

        public Ellipse()
        {
            UpdateValues();
        }

        public override void UpdateValues()
        {
            Random rand = new Random();
            UpdateCX(rand.Next(0, 500));
            UpdateCY(rand.Next(0, 500));
            UpdateRX(rand.Next(2, 50));
            UpdateRY(rand.Next(2, 50));
        }

        public void UpdateCX(int cx)
        {
            this.cx = cx;
        }

        public void UpdateCY(int cy)
        {
            this.cy = cy;
        }

        public void UpdateRX(int rx)
        {
            this.rx = rx;
        }

        public void UpdateRY(int ry)
        {
            this.ry = ry;
        }

        public override string GetTag()
        {
            return $"<ellipse cx=\"{cx}\" cy=\"{cy}\" rx=\"{rx}\" ry=\"{ry}\" stroke=\"#{stroke}\" fill=\"#{fill}\" stroke-width={stroke_width}px />";
        }
    }
}
