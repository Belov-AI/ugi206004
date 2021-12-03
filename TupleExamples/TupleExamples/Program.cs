using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var tuple = (4, 23);
            PrintTuple(tuple);

            var words = new[] { "cab", "bab", "a", "bba", "aab" };
            PrintSequence(words);

            BubbleSort(words);
            PrintSequence(words);

            Console.ReadKey();          
        }

        static void PrintTuple<T,S>((T,S) tuple)
        {
            Console.WriteLine($"Item1: {tuple.Item1}; Item2: {tuple.Item2}");
        }

        static void BubbleSort<T>(T[] array)
            where T: IComparable<T>
        {
            for (var i = 0; i < array.Length - 1; i++)
                for (var j = 0; j < array.Length - 1 - i; j++)
                    if (array[j].CompareTo(array[j + 1]) > 0)
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }
    }
}
