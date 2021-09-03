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


        public double G;
        public double B;

        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new ArgumentException($"Неверное значение {val}. Нужно от 0 до 1");

            return val;
        }
    }
}
