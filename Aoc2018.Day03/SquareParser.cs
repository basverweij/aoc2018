using Aoc2018.Day03.Domain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aoc2018.Day03
{
    public static class SquareParser
    {
        private static Regex _inputPattern = new Regex(@"^#(?<Id>\d+) @ (?<Left>\d+),(?<Top>\d+): (?<Width>\d+)x(?<Height>\d+)$");

        public static IEnumerable<Square> ParseInput(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return ParseLine(line);
            }
        }

        private static Square ParseLine(string line)
        {
            var m = _inputPattern.Match(line);

            if (!m.Success)
            {
                throw new ArgumentException(@"invalid input line: '{line}'", nameof(line));
            }

            return new Square(
                int.Parse(m.Groups[nameof(Square.Id)].Value),
                int.Parse(m.Groups[nameof(Square.Left)].Value),
                int.Parse(m.Groups[nameof(Square.Top)].Value),
                int.Parse(m.Groups[nameof(Square.Width)].Value),
                int.Parse(m.Groups[nameof(Square.Height)].Value));
        }
    }
}
