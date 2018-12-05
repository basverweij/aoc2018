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

            Puzzle2();
        }

        static void Puzzle1()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            var value = new MostMinutesAsleepStrategy().StrategyValue(organizedEvents);

            Console.WriteLine($"Day 04 - Puzzle 1: {value}");
        }

        static void Puzzle2()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            var value = new MostFrequentMinuteAsleepStrategy().StrategyValue(organizedEvents);

            Console.WriteLine($"Day 04 - Puzzle 2: {value}");
        }
    }
}
