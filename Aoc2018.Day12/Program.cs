using Aoc2018.Core.Puzzles;
using Aoc2018.Day12.Common;
using Aoc2018.Day12.Plants;
using System;
using System.IO;
using System.Linq;

namespace Aoc2018.Day12
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
            var input = File.ReadAllLines("input-2018-12.txt");

            var initialState = input.First().Replace("initial state: ", "");

            var combinations = InputParser.Parse(input.Skip(2));

            var grower = new Grower(combinations);

            var pots = grower.Grow(initialState, 20);

            var sum = pots.GetSumOfPotNumbers();

            Console.WriteLine($"Day 12 - Puzzle 1: {sum}");
        }
    }
}
