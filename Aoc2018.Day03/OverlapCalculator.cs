using Aoc2018.Day03.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day03
{
    public static class OverlapCalculator
    {
        public static int GetOverlappingSquares(int size, IEnumerable<Square> squares)
        {
            var grid = Enumerable
                .Range(0, size)
                .Select(i => new int[size])
                .ToArray();

            foreach (var square in squares)
            {
                for (var i = 0; i < square.Height; i++)
                {
                    var gridLine = grid[square.Top + i];

                    for (var j = 0; j < square.Width; j++)
                    {
                        gridLine[square.Left + j]++;
                    }
                }
            }

            return grid.Sum(gridLine => gridLine.Sum(i => i > 1 ? 1 : 0));
        }
    }
}
