using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flags
{
    public class PolandFlag : TwoColoredFlag
    {
        protected override void DrawTopPart()       
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(new string(' ', 7));
            Console.BackgroundColor = ConsoleColor.Black;
        }

        protected override void DrawBottomPart()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(new string(' ', 7));
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
