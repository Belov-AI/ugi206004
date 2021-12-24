using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReflection
{
    public class DescriptionAttribute : Attribute
    {
        public string Label { get; set; }

        public DescriptionAttribute(string note)
        {
            Label = note;
        }
    }
}
