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

            Console.WriteLine(GetLongestWordWithSort(text));
            Console.WriteLine(GetLongestWord(text));

            Console.WriteLine();
            var dict = GetFrequencyDictionary(text);
            PrintFrequencyDictionary(dict);
            PrintFrequencyDictionary(dict
                .OrderByDescending(elem => elem.Value)
                .ToDictionary(elem => elem.Key, elem => elem.Value)
                );

            Console.ReadKey();

        }

        static List<string> GetWordsInAlphabeticalOrder(string[] lines)
        {
            return GetWordsInLowerCase(lines)
                .OrderBy(word => word)
                .Select(word => word.ToLower())
                .Distinct()
                .ToList();
        }

        //Задача 6
        static List<string> GetWordsByLength(string[] lines)
        {
            return GetWordsInLowerCase(lines)
                .Distinct()
                .OrderBy(w => w.Length)
                .ThenBy(w => w)
                .ToList();
        }

        //Задача 7  с сортировкой
        static string GetLongestWordWithSort(string[] lines)
        {
            return GetWordsInLowerCase(lines)
                .Distinct()
                .OrderByDescending(w => w.Length)
                .ThenBy(w => w)
                .FirstOrDefault();
        }

        //Задача 7
        static string GetLongestWord(string[] lines)
        {
            return GetWordsInLowerCase(lines)
                .Distinct()
                .Select(w => (-w.Length, w))
                .Min()
                .Item2;
        }

        //Задача 11
        static Dictionary<char, double> GetFrequencyDictionary(string[] lines)
        {

            var words = GetWordsInLowerCase(lines);
            double totalAmount = words.Count();
            return words
                .GroupBy(w => w[0])
                .OrderBy(g => g.Key)
                .ToDictionary(g => char.ToUpper(g.Key), g => g.Count()/totalAmount);
        }


        static IEnumerable<string> GetWordsInLowerCase(IEnumerable<string> lines)
        {
            return lines
               .SelectMany(line => line.Split(' ', '.', ',', ';', ':', '!', '?', '*', '—', '"', '«', '»'))
               .Where(w => w.Length > 0 && char.IsLetter(w[0]))
               .Select(w => w.ToLower());
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }

        static void PrintFrequencyDictionary(Dictionary<char,double> dictionary)
        {
            foreach (var elem in dictionary)
                Console.WriteLine($"{elem.Key}: {elem.Value:F4}");

            Console.WriteLine();
        }
    }
}
