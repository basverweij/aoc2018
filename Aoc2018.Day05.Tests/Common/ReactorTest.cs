using Aoc2018.Day05.Common;
using Xunit;

namespace Aoc2018.Day05.Tests.Common
{
    public class ReactorTest
    {
        [Theory]
        [InlineData("aA", "")]
        [InlineData("abBA", "")]
        [InlineData("abAB", "abAB")]
        [InlineData("aabAAB", "aabAAB")]
        [InlineData("dabAcCaCBAcCcaDA", "dabCBAcaDA")]
        public void ShouldReactCorrectly(string polymer, string expected)
        {
            Assert.Equal(expected, Reactor.React(polymer));
        }

        [Theory]
        [InlineData('a', 'A', true)]
        [InlineData('A', 'a', true)]
        [InlineData('a', 'b', false)]
        [InlineData('a', 'B', false)]
        public void ShouldTriggerCorrectly(char unit1, char unit2, bool expected)
        {
            Assert.Equal(expected, Reactor.Triggered(unit1, unit2));
        }
    }
}
