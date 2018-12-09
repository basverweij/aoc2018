using Aoc2018.Core.Puzzles;
using Aoc2018.Day07.Common;
using Aoc2018.Day07.Instructions;
using System;
using System.IO;

namespace Aoc2018.Day07
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
            var input = File.ReadAllLines("input-2018-07.txt");

            var instructions = InputParser.Parse(input);

            var result = Organizer.OrganizeInstructions(instructions);

            Console.WriteLine($"Day 07 - Puzzle 1: {result}");
        }
    }
}
