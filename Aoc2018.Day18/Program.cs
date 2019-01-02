using Aoc2018.Core.Puzzles;
using Aoc2018.Day18.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace Aoc2018.Day18
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
            var input = File.ReadAllLines("input-2018-18.txt");

            var area = InputParser.Parse(input);

            for (var i = 0; i < 10; i++)
            {
                area.Grow();
            }

            var value = area.ResourceValue;

            Console.WriteLine($"Day 18 - Puzzle 1: {value}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var input = File.ReadAllLines("input-2018-18.txt");

            var area = InputParser.Parse(input);

            var seen = new Dictionary<string, int>();

            for (var i = 0; i < 1_000_000_000; i++)
            {
                area.Grow();

                var s = area.ToString();
                if (seen.ContainsKey(s))
                {
                    var previousRound = seen[s];

                    Console.WriteLine($"Seen twice (rounds {previousRound} and {i}):");
                    Console.WriteLine(s);

                    var delta = i - previousRound;

                    // skip repeating grow cycles
                    i += (1_000_000_000 - delta - i) / delta * delta;

                    // finish last grows
                    for (++i; i < 1_000_000_000; i++)
                    {
                        area.Grow();
                    }

                    break;
                }

                seen[s] = i;
            }

            Console.WriteLine(area.ToString());

            var value = area.ResourceValue;

            Console.WriteLine($"Day 18 - Puzzle 2: {value}");
        }
    }
}
