using Aoc2018.Core.Puzzles;
using Aoc2018.Day11.Cells;
using System;

namespace Aoc2018.Day11
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        [Puzzle]
        static void Puzzle1()
        {
            var grid = new Grid(300, 300);

            grid.Fill(9798);

            var (x, y, size, _) = grid.FindLargestTotalPower();

            Console.WriteLine($"Day 11 - Puzzle 2: {x},{y},{size}");
        }
    }
}
