using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();

            for(var i =0; i< 10; i++)
                Console.WriteLine($"{rnd.NextDouble(1, 10):F3}");


            Console.ReadKey();
        }
    }
}

