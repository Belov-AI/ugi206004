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
            Console.WriteLine($"Все положительные? {GetAnswer(IsAllPositive(numbers))}");
            Console.WriteLine($"Есть 0? {GetAnswer(IsContainsZero(numbers))}");

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

        //Задача 9 а)
        static bool IsAllPositive(int[] numbers)
        {
            return numbers.All(n => n > 0);
        }

        //Задача 9 б)
        static bool IsContainsZero(int[] numbers)
        {
            return numbers.Any(n => n == 0);
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }

        static string GetAnswer(bool flag)
        {
            return flag ? "Да" : "Нет";
        }
    }
}
