using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Originator
    {
        private List<Shape> state;

        public Originator(List<Shape> state)
        {
            this.state = state;
        }

        public void SetState(List<Shape> state)
        {
            this.state = state;
        }

        public List<Shape> GetState()
        {
            return state;
        }

        public Momento SaveStateToMomento()
        {
            return new Momento(CopyState(state));
        }

        public void GetStateFromMomento(Momento m)
        {
            this.state = m.GetState();
        }

        private static List<Shape> CopyState(List<Shape> state)
        {
            List<Shape> output = new List<Shape>();
            foreach (Shape s in state)
            {
                output.Add(s);
            }

            return output;
        }
    }
}
