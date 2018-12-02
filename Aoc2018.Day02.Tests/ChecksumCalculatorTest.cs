using Xunit;

namespace Aoc2018.Day02.Tests
{
    public class ChecksumCalculatorTest
    {
        [Fact]
        public void CalculateChecksumShouldReturnRightChecksum()
        {
            var ids = new string[]
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab",
            };

            Assert.Equal(12, ChecksumCalculator.CalculateChecksum(ids));
        }
    }
}
