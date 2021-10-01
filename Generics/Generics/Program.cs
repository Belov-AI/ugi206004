using System;

namespace Generics
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Max(new int[0]));
            Console.WriteLine(Max(new[] { 3 }));
            Console.WriteLine(Max(new[] { '+', '-', '*', '/' }));
            Console.WriteLine(Max(new[] { 3, 1, 2 }));
            Console.WriteLine(Max(new[] { "AAB", "ABA", "AAC" }));

            Console.ReadKey();
        }

        static ... Max...(...[] source) ...
        {
            if(source.Length == 0)
            return default(...);
            ...
        }
    }
}
