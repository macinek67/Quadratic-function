using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class PositionList
    {
        public List<Position> positions = new List<Position>();
        public float start, end, step;
        public PositionList(float start, float end, float step)
        {
            this.start = start;
            this.end = end;
            this.step = step;

            for(float x=start; x<=end; x+=step)
            {
                Position p = new Position(x);
                positions.Add(p);
            }
        }
        public PositionList() { }
    }
}
