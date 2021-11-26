using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 8, -3, 15, 28, 101, -35, 10, 15 };

            PrintSequence(numbers);

            //найти и распечатаь только четные числа
            var evenNumbers = numbers.Where(x => x % 2 == 0);
            
            PrintSequence(evenNumbers);

            //вычислить и распечатаь квадраты чисел массива
            var squares = numbers.Select(x => x * x);

            PrintSequence(squares);

            var list = new List<int> { 1, 2, 3, 4, 5 };
            var array = new[] { 5, 6, 7 };
            var stack = new Stack<int>();
            foreach (var n in new[] { 8, 9, 10 })
                stack.Push(n);

            var mergedData = MergeSequences(list, array, stack);
            PrintSequence(mergedData);

            //Составить список слов текста длины не меньше 3 букв в нижнем регистре и вывести на консоль
            var verse = new[]
            {
                "Мой дядя самых честных правил",
                "Когда не в шутку занемог",
                "Он уважать себя заставил",
                "И лучше выдумать не мог"
            };

            var words = verse
                .SelectMany(line => line.Split())
                .Where(word => word.Length > 2)
                .Select(word => word.ToLower())
                .ToList();

            PrintSequence(words);

            //вывести первые три элемента массива чисел
            PrintSequence(numbers.Take(3));

            //вывести массив чисел, начиная с 5-го элемента
            PrintSequence(numbers.Skip(4));

            var sArray = stack.ToArray();
            var sList = stack.ToList();
            PrintSequence(sArray);
            PrintSequence(sList);
            Console.WriteLine(sList.FirstOrDefault());

            //напечатаь первое число из массива чисел, большее 10
            Console.WriteLine(numbers
                .Where(x => x > 10)
                .FirstOrDefault());

            //отсортировать числовой массив по возрастанию без повторов
            PrintSequence(numbers
                .OrderBy(x => x)
                .Distinct()
                );

            //отсортировать слова сначала по длине по убыванию, а затем (если слова одинаковой длины) по алфавиту

            PrintSequence(words
                .OrderByDescending(w => w.Length)
                .ThenBy(w => w)
                );

            Console.ReadKey();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }

        static IEnumerable<T> MergeSequences<T>(params IEnumerable<T>[] sequences)
        {
            return sequences.SelectMany(s => s);
        }
    }
}
