using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle
    {
        public Point TopLeft;
        double width;
        public double Width
        {
            get { return width; }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Ширина должна быть неотрицательной");

                width = value;
            }
        }

        double height;
        public double Height
        {
            get { return height; }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Высота должна быть неотрицательной");

                height = value;
            }
        }

        public Rectangle(Point topLeft, double width, double height)
        {
            TopLeft = topLeft;
            Width = width;
            Height = height;
        }

        public double Area
        {
            get { return Width * Height; }
        }

        public void Draw()
        {
            throw new NotImplementedException();
            // здесь нужно дописать код рисования прямоугольника
        }
    }
}
