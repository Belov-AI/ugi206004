using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReflection
{
    [Description("Класс для учебного проекта \"Рефлексия типов\"")]
    public class MyClass : IComparable<MyClass>
    {
        [Description("Открытое поле")]
        public int PublicField;

        private int privateField = 1;

        [Description("Открытое свойство")]
        public int PublicProperty { get; set; }

        public int CompareTo(MyClass other)
        {
            return this.PublicField.CompareTo(other.PublicField);
        }

        [Description("Открытый метод")]
        public int PublicMethod(int x)
        {
            return x + PublicProperty + privateField;
        }

        private void PrivateMethod()
        {
            Console.WriteLine(privateField);
        }
    }
}
