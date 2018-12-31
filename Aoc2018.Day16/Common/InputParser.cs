using Aoc2018.Day16.Instructions;
using Aoc2018.Day16.Machines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day16.Common
{
    public static class InputParser
    {
        public static IEnumerable<Sample> ParseSamples(IEnumerable<string> input)
        {
            var lines = input.ToArray();

            for (var i = 0; i < lines.Length; i += 4)
            {
                var before = ParseMachine(lines[i]);
                var instruction = ParseInstruction(lines[i + 1]);
                var after = ParseMachine(lines[i + 2]);

                yield return new Sample(before, instruction, after);
            }
        }

        public static IEnumerable<Instruction> ParseInstructions(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return ParseInstruction(line);
            }
        }

        private static Machine ParseMachine(string line)
        {
            var registers = line
                .Substring(9, line.Length - 10)
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return new Machine(registers);
        }

        private static Instruction ParseInstruction(string line)
        {
            var i = line
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            return new Instruction(i[0], i[1], i[2], i[3]);
        }
    }
}
