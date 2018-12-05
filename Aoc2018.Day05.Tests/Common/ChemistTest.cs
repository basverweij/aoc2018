using Aoc2018.Day05.Common;
using Xunit;

namespace Aoc2018.Day05.Tests.Common
{
    public class ChemistTest
    {
        [Fact]
        public void FindShortestPolymerLength()
        {
            var polymer = "dabAcCaCBAcCcaDA";

            Assert.Equal(4, Chemist.FindShortestPolymerLength(polymer));
        }
    }
}
