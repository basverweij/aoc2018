using Aoc2018.Day17.Scans;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aoc2018.Day17.Common
{
    public static class InputParser
    {
        public static IEnumerable<ScanLine> Parse(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return ParseScanLine(line);
            }
        }

        private static readonly Regex _horizontalPattern = new Regex(@"^y=(?<At>[0-9]+), x=(?<From>[0-9]+)..(?<To>[0-9]+)$");

        private static readonly Regex _verticalPattern = new Regex(@"^x=(?<At>[0-9]+), y=(?<From>[0-9]+)..(?<To>[0-9]+)$");

        private static ScanLine ParseScanLine(string line)
        {
            var m = _horizontalPattern.Match(line);
            if (m.Success)
            {
                return new ScanLine(
                    ScanLineOrientations.Horizontal,
                    int.Parse(m.Groups[nameof(ScanLine.At)].Value),
                    int.Parse(m.Groups[nameof(ScanLine.From)].Value),
                    int.Parse(m.Groups[nameof(ScanLine.To)].Value));
            }

            m = _verticalPattern.Match(line);
            if (m.Success)
            {
                return new ScanLine(
                    ScanLineOrientations.Vertical,
                    int.Parse(m.Groups[nameof(ScanLine.At)].Value),
                    int.Parse(m.Groups[nameof(ScanLine.From)].Value),
                    int.Parse(m.Groups[nameof(ScanLine.To)].Value));
            }

            throw new ArgumentException($"invalid scan line: '{line}'", nameof(line));
        }
    }
}
