using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class Photo
    {
        public int Width { get { return Data.GetLength(0); } }

        public int Height { get { return Data.GetLength(1); } }


        public Pixel[,] Data;

        public Photo(int width, int height)
        {
            Data = new Pixel[width, height];
        }
    }
}
