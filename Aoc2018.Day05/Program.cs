using Aoc2018.Day05.Common;
using System;
using System.IO;

namespace Aoc2018.Day05
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        static void Puzzle1()
        {
            var polymer = File.ReadAllText("input.txt").TrimEnd();

            var result = Reactor.React(polymer);

            Console.WriteLine($"Day 05 - Puzzle 1: {result.Length}");
        }
    }
}
