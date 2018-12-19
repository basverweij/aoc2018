using Aoc2018.Day13.Common;
using System;
using Xunit;

namespace Aoc2018.Day13.Tests.Common
{
    public class InputParserTest
    {
        [Fact]
        public void ParsesInput()
        {
            var input = new string[]
            {
                "/->-\\        ",
                "|   |  /----\\",
                "| /-+--+-\\  |",
                "| | |  | v  |",
                "\\-+-/  \\-+--/",
                "  \\------/   ",
            };

            var track = InputParser.Parse(input);

            var actual = track
                .ToString()
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(input, actual);
        }
    }
}
