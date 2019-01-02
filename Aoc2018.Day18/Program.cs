using Aoc2018.Core.Puzzles;
using Aoc2018.Day18.Common;
using System;
using System.IO;

namespace Aoc2018.Day18
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
            var input = File.ReadAllLines("input-2018-18.txt");

            var area = InputParser.Parse(input);

            for (var i = 0; i < 10; i++)
            {
                area.Grow();
            }

            var value = area.ResourceValue;

            Console.WriteLine($"Day 18 - Puzzle 1: {value}");
        }
    }
}
