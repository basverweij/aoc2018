using Aoc2018.Day13.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day13.Common
{
    public static class InputParser
    {
        public static Track Parse(IEnumerable<string> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var lines = input.ToArray();

            if (!lines.Any())
            {
                throw new ArgumentException("no lines found", nameof(input));
            }

            var track = new Track(lines[0].Length, lines.Length);

            for (var y = 0; y < lines.Length; y++)
            {
                ParseLine(track, y, lines[y]);
            }

            return track;
        }

        private static void ParseLine(Track track, int y, string line)
        {
            for (var x = 0; x < line.Length; x++)
            {
                ParseChar(track, y, x, line[x]);
            }
        }

        private static void ParseChar(Track track, int y, int x, char c)
        {
            switch (c)
            {
                case '|':
                    track.AddSection(x, y, SectionTypes.Vertical);
                    break;

                case '-':
                    track.AddSection(x, y, SectionTypes.Horizontal);
                    break;

                case '/':
                    track.AddSection(x, y, SectionTypes.SlopeRight);
                    break;

                case '\\':
                    track.AddSection(x, y, SectionTypes.SlopeLeft);
                    break;

                case '+':
                    track.AddSection(x, y, SectionTypes.Intersection);
                    break;

                case 'v':
                    track.AddSection(x, y, SectionTypes.Vertical);
                    track.AddCart(x, y, Directions.Down);
                    break;

                case '^':
                    track.AddSection(x, y, SectionTypes.Vertical);
                    track.AddCart(x, y, Directions.Up);
                    break;

                case '<':
                    track.AddSection(x, y, SectionTypes.Horizontal);
                    track.AddCart(x, y, Directions.Left);
                    break;

                case '>':
                    track.AddSection(x, y, SectionTypes.Horizontal);
                    track.AddCart(x, y, Directions.Right);
                    break;
            }
        }
    }
}
