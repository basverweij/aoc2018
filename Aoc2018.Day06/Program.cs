using Aoc2018.Core.Puzzles;
using Aoc2018.Day06.Areas;
using Aoc2018.Day06.Common;
using System;
using System.IO;

namespace Aoc2018.Day06
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
            var input = File.ReadAllLines("input-2018-06.txt");

            var coordinates = InputParser.Parse(input);

            var area = AreaFiller.Fill(coordinates);

            var maxSize = AreaAnalyzer.LargestFiniteArea(area);

            Console.WriteLine($"Day 06 - Puzzle 1: {maxSize}");
        }
    }
}
