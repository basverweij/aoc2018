﻿using Aoc2018.Core.Puzzles;
using Aoc2018.Day09.Games;
using System;

namespace Aoc2018.Day09
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
            var score = Game.HighestScore(427, 70723);

            Console.WriteLine($"Day 09 - Puzzle 1: {score}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var score = Game.HighestScore(427, 70723 * 100);

            Console.WriteLine($"Day 09 - Puzzle 2: {score}");
        }
    }
}
