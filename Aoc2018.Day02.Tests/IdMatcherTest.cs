using Xunit;

namespace Aoc2018.Day02.Tests
{
    public class IdMatcherTest
    {
        [Fact]
        public void MatchIdsReturnsMatchingSubstring()
        {
            var ids = new string[]
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz",
            };

            Assert.Equal("fgij", IdMatcher.MatchIds(ids));
        }
    }
}
