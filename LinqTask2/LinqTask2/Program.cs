using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<string>();

            while (true)
            {
                Console.WriteLine("Введите координаты точки через пробел (Enter - конец ввода)");
                var s = Console.ReadLine();
                
                if (s == string.Empty)
                    break;

                input.Add(s);
            }

            PrintSequence(ParsePoints(input));

            Console.ReadKey();
        }

        static List<Point> ParsePoints(List<string> lines)
        {
            return lines
                .Select(line =>
                {
                    var input = line.Split();
                    return new Point(int.Parse(input[0]), int.Parse(input[1]));
                })
                .ToList();

            //return lines
            //    .Select(line => line.Split()
            //        .Select(x => int.Parse(x))
            //        .ToArray())
            //    .Select(a => new Point(a[0], a[1]))
            //    .ToList();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }
    }
}
