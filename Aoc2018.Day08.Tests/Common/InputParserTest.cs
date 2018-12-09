using Aoc2018.Day08.Common;
using Xunit;

namespace Aoc2018.Day08.Tests.Common
{
    public class InputParserTest
    {
        [Fact]
        public void ParsesInput()
        {
            var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            var expected = new int[] { 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2 };

            Assert.Equal(expected, InputParser.Parse(input));
        }
    }
}
