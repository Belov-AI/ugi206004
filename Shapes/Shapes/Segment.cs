using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Segment : LinearObject
    {
        public double Length
        {
            get
            {
                var deltaX = P2.X - P1.X;
                var deltaY = P2.Y - P1.Y;
                return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            }
        }

        public Segment(Point p1, Point p2) : base(p1, p2) { }

        public override bool IsOn(Point p)
        {
            return IsOnLine(p) && (P2.X - p.X) * (p.X - P1.X) > -1e-8;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
