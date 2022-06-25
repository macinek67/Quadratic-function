using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Position
    {
        public float x { get; set; }
        public float f { get; set; }
        public Position(float x) { this.x = x; f = F(x); }
        public float F(float x) { return (x*x)-3; }
    }
}
