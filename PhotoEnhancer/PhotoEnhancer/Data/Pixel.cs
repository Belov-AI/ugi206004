using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    //пиксел имеет 3 канала, яркости которых - число от 0 до 1
    public class Pixel
    {
        double r;
        public double R
        {
            get { return r; }

            set { r = CheckValue(value); }
        }

        double g;
        public double G
        {
            get { return g; }

            set { g = CheckValue(value); }
        }

        double b;
        public double B
        {
            get { return b; }

            set { b = CheckValue(value); }
        }

        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new ArgumentException($"Неверное значение {val}. Нужно от 0 до 1");

            return val;
        }
    }
}
