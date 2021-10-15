using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flags
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            var flags = new TwoColoredFlag[]
            {
                new UkraineFlag(),
                new PolandFlag()
            };
            
            foreach (var flag in flags)
            {
                flag.Draw();
                Console.WriteLine();
            }

            

            Console.ReadKey();
        }
    }
}
