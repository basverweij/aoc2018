using Aoc2018.Day10.Points;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aoc2018.Day10.Common
{
    public static class InputParser
    {
        public static IEnumerable<Point> Parse(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return ParseLine(line);
            }
        }

        private static readonly Regex _inputPattern = new Regex(@"position=< *(?<X>-?[0-9]+), *(?<Y>-?[0-9]+)> velocity=< *(?<VelocityX>-?[0-9]+), *(?<VelocityY>-?[0-9]+)>");

        private static Point ParseLine(string line)
        {
            var m = _inputPattern.Match(line);
            if (!m.Success)
            {
                throw new ArgumentException($"invalid input line: '{line}'", nameof(line));
            }

            return new Point(
                int.Parse(m.Groups[nameof(Point.X)].Value),
                int.Parse(m.Groups[nameof(Point.Y)].Value),
                int.Parse(m.Groups[nameof(Point.VelocityX)].Value),
                int.Parse(m.Groups[nameof(Point.VelocityY)].Value));
        }
    }
}
