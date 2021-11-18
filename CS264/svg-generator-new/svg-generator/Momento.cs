using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Momento
    {
        private readonly List<Shape> state;

        public Momento (List<Shape> state)
        {
            this.state = state;
        }

        public List<Shape> GetState()
        {
            return state;
        }
    }
}
