using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Caretaker
    {
        private Stack<Momento> momentoStack;

        public Caretaker()
        {
            momentoStack = new Stack<Momento>();
        }

        public void Push(Momento m)
        {
            momentoStack.Push(m);
        }

        public Momento Pop()
        {
            return momentoStack.Pop();
        }

        public void Clear()
        {
            momentoStack = new Stack<Momento>();
        }
    }
}
