using Aoc2018.Day06.Areas;
using Aoc2018.Day06.Coordinates;
using Xunit;

namespace Aoc2018.Day06.Tests.Areas
{
    public class AreaAnalyzerTest
    {
        [Fact]
        public void FindsLargestFiniteArea()
        {
            var coordinates = new Coordinate[]
            {
                new Coordinate(0, 1, 1),
                new Coordinate(1, 1, 6),
                new Coordinate(2, 8, 3),
                new Coordinate(3, 3, 4),
                new Coordinate(4, 5, 5),
                new Coordinate(5, 8, 9),
            };

            var area = AreaFiller.Fill(coordinates);

            Assert.Equal(17, AreaAnalyzer.LargestFiniteArea(area));
        }
    }
}
