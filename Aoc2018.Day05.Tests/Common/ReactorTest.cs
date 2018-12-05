using Aoc2018.Day05.Common;
using Xunit;

namespace Aoc2018.Day05.Tests.Common
{
    public class ReactorTest
    {
        [Theory]
        [InlineData("aA", "")]
        [InlineData("abBA", "aA")]
        [InlineData("abAB", "abAB")]
        [InlineData("aabAAB", "aabAAB")]
        [InlineData("dabAcCaCBAcCcaDA", "dabCBAcaDA")]
        public void ShouldReactCorrectly(string polymer, string expected)
        {
            Assert.Equal(expected, Reactor.React(polymer));
        }
    }
}
