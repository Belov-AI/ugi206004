using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class LinearObject
    {
        public Point P1;
        public Point P2;

        public double K { get { return (P2.Y - P1.Y) / (P2.X - P1.X); } }

        public double B { get { return P1.Y - K * P1.X; } }

        public LinearObject(Point p1, Point p2)
        {
            if (p1.X == p2.X)
                throw new ArgumentException("Точки лежат на одной вертикали");

            P1 = p1;
            P2 = p2;
        }

        public abstract bool IsOn(Point p);

        public abstract void Draw();

        protected bool IsOnLine(Point p)
        {
            return Math.Abs(p.Y - K * p.X - B) < 1e-8;
        }
    }
}
