using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTask4
{
    public class Photo
    {
        public readonly int Width;

        public readonly int Height;

        private readonly Pixel[,] data;

        public Photo(int width, int height)
        {
            Width = width;
            Height = height;

            data = new Pixel[width, height];

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    data[x, y] = new Pixel(0, 0, 0);
        }

        public Pixel this[int x, int y]
        {
            get { return data[x, y]; }

            set { data[x, y] = value; }
        }

        public List<Pixel> GetNeighbours(Point p)
        {
            var delta = new[] { -1, 0, 1 };

            return delta
                .SelectMany(dx => delta.Select(dy => (X: p.X + dx, Y: p.Y + dy)))
                .Where(t => t.X >= 0 && t.X < Width &&
                    t.Y >= 0 && t.Y < Height &&
                    (t.X != p.X || t.Y != p.Y))
                .Select(t => data[t.X, t.Y])
                .ToList();
        }
    }
}
