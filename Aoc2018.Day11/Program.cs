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

            Puzzle2();
        }

        [Puzzle]
        static void Puzzle1()
        {
            var grid = new Grid(300, 300);

            grid.Fill(9798);

            var (x, y, _, _) = grid.FindLargestTotalPower(3, 3);

            Console.WriteLine($"Day 11 - Puzzle 1: {x},{y}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var grid = new Grid(300, 300);

            grid.Fill(9798);

            var (x, y, size, _) = grid.FindLargestTotalPower(1, 300);

            Console.WriteLine($"Day 11 - Puzzle 2: {x},{y},{size}");
        }
    }
}
