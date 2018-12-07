using Aoc2018.Core.Puzzles;
using System;
using System.IO;

namespace Aoc2018.Day02
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
            var ids = File.ReadAllLines("input-2018-02.txt");

            var checksum = ChecksumCalculator.CalculateChecksum(ids);

            Console.WriteLine($"Day 02 - Puzzle 1: {checksum}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var ids = File.ReadAllLines("input-2018-02.txt");

            var matchingId = IdMatcher.MatchIds(ids);

            Console.WriteLine($"Day 02 - Puzzle 2: {matchingId}");
        }
    }
}
