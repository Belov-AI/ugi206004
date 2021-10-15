using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
    public static class RandomExtention
    {
        public static double NextDouble(this Random rnd, double minValue, double maxValue)
        {
            if(minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue не может быть больше maxValue");

            return rnd.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
