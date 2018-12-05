using Aoc2018.Day04.Common;
using System;
using System.IO;

namespace Aoc2018.Day04
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        static void Puzzle1()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            var value = MostMinutesAsleepStrategy.StrategyValue(organizedEvents);

            Console.WriteLine($"Day 04 - Puzzle 1: {value}");
        }
    }
}
