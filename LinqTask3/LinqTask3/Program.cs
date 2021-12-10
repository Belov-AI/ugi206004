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
                new Group() {Students = new List<string>{"Елена", "Андрей" } },
                new Group() { Students = new List<string>{ "Николай"} }
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
            Console.WriteLine($"Общее число студентов: {GetTotalAmountOfStudents(groups)}");
            Console.WriteLine($"Среднее число студентов в группе: {GetAverageofStudentsPerGroup(groups):F3}");

            Console.ReadKey();
        }

        //Задача 8
        static int GetTotalAmountOfStudents(List<Group> groups)
        {
            return groups
                .SelectMany(g => g.Students)
                .Count();
        }

        static double GetAverageofStudentsPerGroup(List<Group> groups)
        {
            return groups.Average(g => g.Students.Count());
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine("\n");
        }
    }
}
