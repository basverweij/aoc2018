using Aoc2018.Day06.Common;
using Aoc2018.Day06.Coordinates;
using System.Collections.Generic;
using Xunit;

namespace Aoc2018.Day06.Tests.Common
{
    public class InputParserTest
    {
        [Fact]
        public void ParsesInput()
        {
            var input = new string[]
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            };

            IEnumerable<Coordinate> expected = new Coordinate[]
            {
                new Coordinate(0, 1, 1),
                new Coordinate(1, 1, 6),
                new Coordinate(2, 8, 3),
                new Coordinate(3, 3, 4),
                new Coordinate(4, 5, 5),
                new Coordinate(5, 8, 9),
            };

            var coordinates = InputParser
                .Parse(input);

            Assert.Equal(expected, coordinates);
        }
    }
}
