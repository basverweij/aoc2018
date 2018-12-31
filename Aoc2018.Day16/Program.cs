using Aoc2018.Core.Puzzles;
using Aoc2018.Day16.Common;
using System;
using System.IO;
using System.Linq;

namespace Aoc2018.Day16
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
            var input = File.ReadAllLines("input-2018-16-1.txt");

            var samples = InputParser.ParseSamples(input);

            var count = samples
                .Where(s => MachineUtil
                    .FindMatchingOpcodes(s.Before, s.Instruction.A, s.Instruction.B, s.Instruction.C, s.After)
                    .Count() >= 3)
                .Count();

            Console.WriteLine($"Day 16 - Puzzle 1: {count}");
        }

        [Puzzle]
        static void Puzzle2()
        {
            var input = File.ReadAllLines("input-2018-16-1.txt");

            var samples = InputParser.ParseSamples(input);

            var opcodeLookup = MachineUtil.BuildOpcodeLookup(samples);

            Console.WriteLine(string.Join(Environment.NewLine, opcodeLookup.OrderBy(l => l.Key).Select(l => $"{l.Key} = {l.Value}")));

            input = File.ReadAllLines("input-2018-16-2.txt");

            var instructions = InputParser.ParseInstructions(input);

            var machine = MachineUtil.ExecuteProgram(instructions, opcodeLookup);

            Console.WriteLine(machine);
        }
    }
}
