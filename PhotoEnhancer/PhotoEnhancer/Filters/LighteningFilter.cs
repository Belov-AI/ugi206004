using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : IFilter
    {
        public ParameterInfo[] GetParametersInfo()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Коэффициент",
                    MinValue = 0,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.05
                }
            };
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var resultPhoto = new Photo(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
                for (int y = 0; y < original.Height; y++)
                    resultPhoto[x, y] = original[x, y] * parameters[0];

            return resultPhoto;      
        }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}
