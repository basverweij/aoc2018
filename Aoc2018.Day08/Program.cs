using Aoc2018.Core.Puzzles;
using Aoc2018.Day08.Common;
using Aoc2018.Day08.Trees;
using System;
using System.IO;

namespace Aoc2018.Day08
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
            var input = File.ReadAllText("input-2018-08.txt");

            var data = InputParser.Parse(input);

            var root = TreeBuilder.Build(data);

            var metadataSum = TreeAnalyzer.GetMetadataSum(root);

            Console.WriteLine($"Day 08 - Puzzle 1: {metadataSum}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var input = File.ReadAllText("input-2018-08.txt");

            var data = InputParser.Parse(input);

            var root = TreeBuilder.Build(data);

            var value = TreeAnalyzer.GetNodeValue(root);

            Console.WriteLine($"Day 08 - Puzzle 2: {value}");
        }
    }
}
