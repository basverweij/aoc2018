using Aoc2018.Day06.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day06.Common
{
    public static class InputParser
    {
        public static IEnumerable<Coordinate> Parse(IEnumerable<string> input)
        {
            var id = 0;

            foreach (var line in input)
            {
                yield return Parse(line, id++);
            }
        }

        private static Coordinate Parse(string line, int id)
        {
            var i = line
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            if (i.Length != 2)
            {
                throw new ArgumentException($"invalid input line: '{line}'", nameof(line));
            }

            return new Coordinate(id, i[0], i[1]);
        }
    }
}
