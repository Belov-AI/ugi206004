using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полное имя файла");
            var fileName = Console.ReadLine();
            
            string[] text;

            if (File.Exists(fileName))
                text = File.ReadAllLines(fileName);
            else
            {
                Console.WriteLine("Такого файла не существует");
                Console.ReadKey();
                return;
            }

            PrintSequence(GetWordsInAlphabeticalOrder(text));

            Console.WriteLine();

            PrintSequence(GetWordsByLength(text));

            Console.ReadKey();

        }

        static List<string> GetWordsInAlphabeticalOrder(string[] lines)
        {
            return lines
                .SelectMany(line => line.Split(' ', '.', ',', ';', ':', '!', '?', '*', '—', '"', '«', '»'))
                .Where(word => word.Length > 0 && char.IsLetter(word[0]))
                .OrderBy(word => word)
                .Select(word => word.ToLower())
                .Distinct()
                .ToList();
        }

        //Задача 6
        static List<string> GetWordsByLength(string[] lines)
        {
            return lines
                .SelectMany(line => line.Split(' ', '.', ',', ';', ':', '!', '?', '*', '—', '"', '«', '»'))
                .Where(w => w.Length > 0 && char.IsLetter(w[0]))
                .Select(w => w.ToLower())
                .Distinct()
                .OrderByDescending(w => w.Length)
                .ThenBy(w => w)
                .ToList();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }
    }
}
