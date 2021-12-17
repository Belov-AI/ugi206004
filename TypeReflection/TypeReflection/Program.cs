using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TypeReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(MyClass);
            PrintTypeName(type);
            ListMethods(type);
            ListFields(type);
            ListProperties(type);
            ListPrivateFields(type);
            ListInterFaces(type);

            var type2 = Type.GetType("System.Array", false);
            //PrintTypeName(type2);
            //ListMethods(type2);

            var list = new Dictionary<int,int>();
            var type3 = list.GetType();
            //PrintTypeName(type3);

            var obj = new MyClass();
            obj.PublicProperty = 5;
            obj.PublicField = -2;
            var result = obj.PublicMethod(3);

            var x = type
                .GetProperty("PublicProperty")
                .GetValue(obj);

            type
                .GetProperty("PublicProperty")
                .SetValue(obj, 10);

            obj.PublicProperty = 10;

            Console.ReadKey();
        }

        static void PrintTypeName(Type t)
        {
            Console.WriteLine("===== Тип =====");
            Console.WriteLine(t.Name);
            Console.WriteLine();
        }

        static void ListMethods(Type t)
        {
            Console.WriteLine("===== Открытые методы =====");
            var methods = t.GetMethods();

            foreach (var method in methods)
                Console.WriteLine($"-> {method.Name}");

            Console.WriteLine();
        }

        static void ListFields(Type t)
        {
            Console.WriteLine("===== Открытые поля =====");
            var fields = t.GetFields();

            foreach (var field in fields)
                Console.WriteLine($"-> {field.Name}");

            Console.WriteLine();
        }

        static void ListPrivateFields(Type t)
        {
            Console.WriteLine("===== Закрытые поля =====");
            var fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
                Console.WriteLine($"-> {field.Name}");

            Console.WriteLine();
        }

        static void ListProperties(Type t)
        {
            Console.WriteLine("===== Открытые свойства =====");
            var props = t.GetProperties();

            foreach (var prop in props)
                Console.WriteLine($"-> {prop.Name}");

            Console.WriteLine();
        }

        static void ListInterFaces(Type t)
        {
            Console.WriteLine("===== Интерфейсы =====");
            var ifaces = t.GetInterfaces();

            foreach (var iface in ifaces)
                Console.WriteLine($"-> {iface.Name}");

            Console.WriteLine();
        }
    }
}
