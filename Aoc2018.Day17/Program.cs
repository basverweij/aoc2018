﻿using Aoc2018.Core.Puzzles;
using Aoc2018.Day17.Analysis;
using Aoc2018.Day17.Common;
using Aoc2018.Day17.Scans;
using System;
using System.IO;

namespace Aoc2018.Day17
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
            var input = File.ReadAllLines("input-2018-17.txt");

            var scan = new Scan(InputParser.Parse(input));

            var count = Analyzer.GetReachableWaterCellsCount(scan);

            Console.WriteLine($"Day 17 - Puzzle 1: {count}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var input = File.ReadAllLines("input-2018-17.txt");

            var scan = new Scan(InputParser.Parse(input));

            var count = Analyzer.GetSettledWaterCellsCount(scan);

            Console.WriteLine($"Day 17 - Puzzle 2: {count}");

            File.WriteAllText(@"C:\Temp\day17_puzzle2.txt", scan.ToString());
        }
    }
}
