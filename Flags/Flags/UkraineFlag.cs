using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flags
{
    public class UkraineFlag : TwoColoredFlag
    {
        protected override void DrawTopPart()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 7));
            Console.BackgroundColor = ConsoleColor.Black;
        }

        protected override void DrawBottomPart()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string(' ', 7));
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
