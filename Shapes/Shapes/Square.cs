using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Rectangle
    {
        public Square(Point topLeft, double side) : base(topLeft, side, side) { }

        public override double Width
        {
            get { return base.Width; }

            set { SetSide(value); }
        }

        public override double Height
        {
            get { return base.Height; }

            set { SetSide(value); }
        }

        private void SetSide(double value)
        {
            base.Width = value;
            base.Height = value;
        }
    }
}
