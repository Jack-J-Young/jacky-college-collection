using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Momento
    {
        public List<Shape> state;

        public Momento (List<Shape> state)
        {
            this.state = state;
        }
    }
}
