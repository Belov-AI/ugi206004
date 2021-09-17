using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class GrayScaleFilter : PixelFilter
    {
        public override ParameterInfo[] GetParametersInfo()
        {
            return new ParameterInfo[0];
        }

        public override Pixel ProcessPixel(Pixel original, double[] parameters)
        {
            var channel = 0.3 * original.R + 0.6 * original.G + 0.1 * original.B;
            return new Pixel(channel, channel, channel);
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }
    }
}
