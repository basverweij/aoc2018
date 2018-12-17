using Aoc2018.Day12.Combinations;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aoc2018.Day12.Common
{
    public static class InputParser
    {
        public static IEnumerable<Combination> Parse(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return ParseLine(line);
            }
        }

        private static readonly Regex _inputFormat = new Regex(@"^(?<Mask>[.#]{5}) => (?<ProducesNext>[.#]{1})$");

        private static Combination ParseLine(string line)
        {
            var m = _inputFormat.Match(line);
            if (!m.Success)
            {
                throw new ArgumentException($"invalid input line: '{line}'", nameof(line));
            }

            var mask = m
                .Groups[nameof(Combination.Mask)]
                .Value;

            var producesNext = m
                .Groups[nameof(Combination.ProducesNext)]
                .Value
                .Equals("#", StringComparison.InvariantCultureIgnoreCase);

            return new Combination(mask, producesNext);
        }
    }
}
