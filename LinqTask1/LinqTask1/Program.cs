using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла");
            var file = Console.ReadLine();

            var numbers = GetNumbers(GetLinesFromFile(file));
            PrintSequence(numbers);

            Console.ReadKey();
        }

        static int[] GetNumbers(string[] lines)
        {
            return lines
                .Where(line => line.Length > 0)
                .Select(line => int.Parse(line))
                .ToArray();
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
