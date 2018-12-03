using Aoc2018.Day03.Domain;
using Xunit;

namespace Aoc2018.Day03.Tests
{
    public class SquareParserTest
    {
        [Fact]
        public void ParseInputReturnsSquares()
        {
            var input = new string[]
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            };

            var expected = new Square[]
            {
                new Square(1, 1, 3, 4, 4),
                new Square(2, 3, 1, 4, 4),
                new Square(3, 5, 5, 2, 2),
            };

            Assert.Equal(expected, SquareParser.ParseInput(input));
        }
    }
}
