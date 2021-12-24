using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public static class ParametersExtensions
    {
        public static ParameterInfo[] GetDescription(this IParameters parameters)
        {
            return parameters
                .GetType()
                .GetProperties()
                .Select(p => p.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(a => a.Length > 0)
                .SelectMany(a => a)
                .Cast<ParameterInfo>()
                .ToArray();
        }
        public static void SetValues(this IParameters parameters, double[] values)
        {
            var properties = parameters
                .GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();

            if (properties.Length != values.Length)
                throw new ArgumentException();

            for (var i = 0; i < values.Length; i++)
                properties[i].SetValue(parameters, values[i]);
        }
    }
}
