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

            Puzzle2();
        }

        [Puzzle]
        static void Puzzle1()
        {
            var input = File.ReadAllLines("input-2018-06.txt");

            var coordinates = InputParser.Parse(input);

            var area = AreaFiller.Fill(coordinates, AreaFiller.FillForCoordinate);

            var maxSize = AreaAnalyzer.LargestFiniteArea(area);

            Console.WriteLine($"Day 06 - Puzzle 1: {maxSize}");
        }

        [Puzzle]
        private static void Puzzle2()
        {
            var input = File.ReadAllLines("input-2018-06.txt");

            var coordinates = InputParser.Parse(input);

            var area = AreaFiller.Fill(coordinates, AreaFiller.SumForCoordinate);

            var size = AreaAnalyzer.AreaLessThanMaxDistance(area, 10000);

            Console.WriteLine($"Day 06 - Puzzle 2: {size}");
        }
    }
}
