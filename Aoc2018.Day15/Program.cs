using Aoc2018.Core.Puzzles;
using Aoc2018.Day15.Common;
using Aoc2018.Day15.Games;
using System;
using System.IO;

namespace Aoc2018.Day15
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        [Puzzle]
        private static void Puzzle1()
        {
            var input = File.ReadAllLines("input-2018-15.txt");

            var area = InputParser.Parse(input);

            Console.WriteLine(area);

            var game = new Game(area, new DefaultMoveStrategy(), new DefaultAttackStrategy());

            for (var i = 0; i < 1; i++)
            {
                if (!game.Turn())
                {
                    break;
                }
            }

            Console.WriteLine($"Day 15 - Puzzle 1: {game.Score}");
        }
    }
}
