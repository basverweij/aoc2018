using Aoc2018.Core.Puzzles;
using System;
using System.IO;

namespace Aoc2018.Day03
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
            var input = File.ReadAllLines("input-2018-03.txt");

            var squares = SquareParser.ParseInput(input);

            var overlap = OverlapCalculator.GetOverlappingSquares(1000, squares);

            Console.WriteLine($"Day 03 - Puzzle 1: {overlap}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var input = File.ReadAllLines("input-2018-03.txt");

            var squares = SquareParser.ParseInput(input);

            var square = OverlapCalculator.GetNonOverlappingSquare(1000, squares);

            Console.WriteLine($"Day 03 - Puzzle 2: {square.Id}");
        }
    }
}
