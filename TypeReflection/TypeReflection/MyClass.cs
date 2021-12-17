using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReflection
{
    public class MyClass : IComparable<MyClass>
    {
        public int PublicField;
        private int privateField;
        public int PublicProperty { get; set; }

        public int CompareTo(MyClass other)
        {
            return this.PublicField.CompareTo(other.PublicField);
        }

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
