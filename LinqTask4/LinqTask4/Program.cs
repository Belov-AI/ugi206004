using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            var photo = new Photo(100, 200);

            var neighbours = photo.GetNeighbours(new Point(0, 0));
        }
    }
}
