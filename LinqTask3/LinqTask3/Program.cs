using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<Group>
            {
                new Group() {Students = new List<string>{"Николай", "Пётр", "Елена", "Наталья"}},
                new Group() {Students = new List<string>{"Софья", "Андрей", "Николай" } },
                new Group() {Students = new List<string>()},
                new Group() {Students = new List<string>{"Елена", "Андрей" } }
            };


            //var students = groups
            //    .SelectMany(group => group.Students)
            //    .ToList();

            //PrintSequence(students);

            //получить список имен всех студентов в алфавитном порядке
            var names = groups
                .SelectMany(group => group.Students)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            PrintSequence(names);


            Console.ReadKey();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }
    }
}
