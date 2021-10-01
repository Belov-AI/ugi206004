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

        static T Max<T> (T[] source) where T : IComparable<T>
        {
            if(source.Length == 0)
                return default(T);

            if (source.Length == 1)
                return source[0];

            var max = source[0];

            for (var i = 1; i < source.Length; i++)
                if (source[i].CompareTo(max) > 0 )
                    max = source[i];

            return max;
        }
    }
}
