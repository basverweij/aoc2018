using Aoc2018.Core.Puzzles;
using System;
using System.IO;

namespace Aoc2018.Day01
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
            var input = File.ReadAllLines("input-2018-01.txt");

            var frequencies = FrequencyParser.Parse(input);

            var result = FrequencyCalibrator.CalculateFrequency(frequencies);

            Console.WriteLine($"Day 01 - Puzzle 1: {result}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var input = File.ReadAllLines("input-2018-01.txt");

            var frequencies = FrequencyParser.Parse(input);

            var result = FrequencyCalibrator.GetFirstDuplicateFrequency(frequencies);

            Console.WriteLine($"Day 01 - Puzzle 2: {result}");
        }
    }
}
