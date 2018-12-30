using Aoc2018.Day15.Common;
using System;
using Xunit;

namespace Aoc2018.Day15.Tests.Common
{
    public class InputParserTest
    {
        [Fact]
        public void ParsesInput()
        {
            var input = new string[]
            {
                    "#######",
                    "#E..G.#",
                    "#...#.#",
                    "#.G.#G#",
                    "#######",
            };

            var area = InputParser.Parse(input);

            var expected = string.Join(Environment.NewLine, input) + Environment.NewLine;

            Assert.Equal(expected, area.ToString());
        }
    }
}
