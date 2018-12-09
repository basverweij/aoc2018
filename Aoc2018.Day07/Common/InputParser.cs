using Aoc2018.Day07.Instructions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aoc2018.Day07.Common
{
    public static class InputParser
    {
        public static IEnumerable<Instruction> Parse(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return ParseLine(line);
            }
        }

        private static readonly Regex _inputFormat = new Regex(@"Step (?<RequiredStep>[A-Z]) must be finished before step (?<ForStep>[A-Z]) can begin.");

        private static Instruction ParseLine(string line)
        {
            var m = _inputFormat.Match(line);
            if (!m.Success)
            {
                throw new ArgumentException($"invalid input line: '{line}'", nameof(line));
            }

            var requiredStep = m.Groups[nameof(Instruction.RequiredStep)].Value[0];
            var forStep = m.Groups[nameof(Instruction.ForStep)].Value[0];

            return new Instruction(requiredStep, forStep);
        }
    }
}
