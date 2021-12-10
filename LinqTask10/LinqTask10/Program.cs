using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла");
            var file = Console.ReadLine();

            var numbers = GetDoubleNumbers(GetLinesFromFile(file));
            PrintSequence(numbers);
            Console.WriteLine($"Среднее геометрическое: {GetGeometricalAverage(numbers):F3}");
            Console.WriteLine($"Среднее геометрическое 2: {GetGeometricalAverage2(numbers):F3}");

            Console.WriteLine($"Среднее геометрическое: {GetGeometricalAverage2(new double[0]):F3}");

            Console.ReadKey();
        }

        static double[] GetDoubleNumbers(string[] lines)
        {
            return lines
                .Where(line => line.Length > 0)
                .Select(line => double.Parse(line))
                .ToArray();
        }

        //Решение 1
        static double GetGeometricalAverage(double[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("Массив пустой");

            var product = values.Aggregate((s, x) => s * x);

            return Math.Pow(product, 1.0 / values.Length);
        }

        //Решение 2
        static double GetGeometricalAverage2(IEnumerable<double> values)
        {
            return values.Aggregate((Product: 1.0, Counter: 0),
                (s, x) => (s.Product * x, s.Counter + 1),
                s =>
                {
                    if (s.Counter == 0)
                        throw new ArgumentException("Массив пустой");

                    return Math.Pow(s.Product, 1.0 / s.Counter);
                });
        }

        static string[] GetLinesFromFile(string fileName)
        {
            if (File.Exists(fileName))
                return File.ReadAllLines(fileName);

            return new string[0];
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }
    }
}
