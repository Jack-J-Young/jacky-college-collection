using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Command
    {
        public int type;
        public string[] args;

        public Command(int type, string[] args)
        {
            this.type = type;
            this.args = args;
        }
    }
}
