using System;

namespace Aoc2018.Day11.Tables
{
    public class SummedAreaTable
    {
        public int Width { get; }

        public int Height { get; }

        private readonly int[,] _data;

        public SummedAreaTable(int width, int height)
        {
            Width = width;
            Height = height;

            _data = new int[width + 1, height + 1]; // first row and column remain zero
        }

        public void Fill(Func<int, int, int> filler)
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var v = filler(i, j);

                    _data[i + 1, j + 1] = v + _data[i, j + 1] + _data[i + 1, j] - _data[i, j];
                }
            }
        }

        public int GetAreaSum(int left, int top, int right, int bottom)
        {
            return _data[right + 1, bottom + 1] - _data[left, bottom + 1] - _data[right + 1, top] + _data[left, top];
        }
    }
}
