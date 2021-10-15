﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle
    {
        public Point Center;

        double radius;
        public double Radius
        {
            get { return radius; }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Радиус должен быть неотрицательным");

                radius = value;
            }
        }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        public void Draw()
        {
            throw new NotImplementedException();
            // здесь нужно дописать код рисования круга
        }
    }
}
