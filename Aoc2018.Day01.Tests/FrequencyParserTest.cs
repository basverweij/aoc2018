using Xunit;

namespace Aoc2018.Day01.Tests
{
    public class FrequencyParserTest
    {
        [Fact]
        public void ParsesInput()
        {
            var input = new string[]
            {
                "+1",
                "-2",
                "+3",
                "+1",
            };

            var expected = new int[]
            {
                1,
                -2,
                3,
                1,
            };

            var actual = FrequencyParser.Parse(input);

            Assert.Equal(expected, actual);
        }
    }
}
