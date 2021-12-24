using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoEnhancer;

namespace Profiler
{
    class Program
    {
        static void Main()
        {
            TestLighteningParameters((values, parameners) => parameners.SetValues(values), 500000);
            TestLighteningParameters((values, parameters) => parameters.Coefficent = values[0], 500000);

            Console.ReadKey();
        }

        static void TestLighteningParameters(Action<double[], LighteningParameters> action, int n)
        {
            var values = new double[] { 1 };
            var parameters = new LighteningParameters();

            action(values, parameters);

            var watch = new Stopwatch();
            watch.Start();

            for (var i = 0; i < n; i++)
                action(values, parameters);

            watch.Stop();

            Console.WriteLine(1000.0 * watch.ElapsedMilliseconds / n);
        }
    }
}
