using Aoc2018.Day03.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day03
{
    public static class OverlapCalculator
    {
        public static int GetOverlappingSquares(int size, IEnumerable<Square> squares)
        {
            var grid = BuildGrid(size, squares);

            return grid.Sum(gridLine => gridLine.Sum(i => i > 1 ? 1 : 0));
        }

        public static Square GetNonOverlappingSquare(int size, IEnumerable<Square> squares)
        {
            var grid = BuildGrid(size, squares);

            foreach (var square in squares)
            {
                var overlap = false;

                for (var i = 0; i < square.Height; i++)
                {
                    var gridLine = grid[square.Top + i];

                    for (var j = 0; j < square.Width; j++)
                    {
                        if (gridLine[square.Left + j] != 1)
                        {
                            overlap = true;
                            break;
                        }
                    }

                    if (overlap)
                    {
                        break;
                    }
                }

                if (!overlap)
                {
                    return square;
                }
            }

            throw new InvalidOperationException("non-overlapping square not found");
        }

        private static int[][] BuildGrid(int size, IEnumerable<Square> squares)
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

            return grid;
        }
    }
}
