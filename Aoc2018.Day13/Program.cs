using Aoc2018.Core.Puzzles;
using Aoc2018.Day13.Common;
using Aoc2018.Day13.Tracks;
using System;
using System.IO;

namespace Aoc2018.Day13
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
            var input = File.ReadAllLines("input-2018-13.txt");

            var track = InputParser.Parse(input);

            try
            {
                while (true)
                {
                    track.Tick();
                }
            }
            catch (CartCollisionException ccex)
            {
                Console.WriteLine($"Day 13 - Puzzle 1: {ccex.Location.X},{ccex.Location.Y}");
            }
        }
    }
}
