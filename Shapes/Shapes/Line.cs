using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Line : LinearObject
    {
        public Line(Point p1, Point p2) : base(p1, p2) { }      

        public override bool IsOn(Point p)
        {
            return IsOnLine(p);
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
