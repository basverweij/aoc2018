using Aoc2018.Core.Puzzles;
using Aoc2018.Day10.Common;
using Aoc2018.Day10.Points;
using System;
using System.IO;

namespace Aoc2018.Day10
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
            var input = File.ReadAllLines("input-2018-10.txt");

            var points = InputParser.Parse(input);

            for (var s = 10_027; ;)
            {
                Console.Clear();

                Console.SetCursorPosition(0, 0);

                Console.WriteLine(s);

                Console.WriteLine();

                points.At(s).Draw(200, 20);

                var k = Console.ReadKey();

                var step = k.Modifiers.HasFlag(ConsoleModifiers.Shift) ? 1 : 10;

                if (k.KeyChar == '-')
                {
                    s -= step;
                }
                else
                {
                    s += step;
                }
            }
        }
    }
}
