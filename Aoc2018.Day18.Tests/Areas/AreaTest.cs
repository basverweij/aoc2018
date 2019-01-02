using Aoc2018.Day18.Common;
using Xunit;
using Xunit.Abstractions;

namespace Aoc2018.Day18.Tests.Areas
{
    public class AreaTest
    {
        private readonly ITestOutputHelper _output;

        public AreaTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Grows()
        {
            var input = new string[]
            {
                ".#.#...|#.",
                ".....#|##|",
                ".|..|...#.",
                "..|#.....#",
                "#.#|||#|#|",
                "...#.||...",
                ".|....|...",
                "||...#|.#|",
                "|.||||..|.",
                "...#.|..|.",
            };

            var area = InputParser.Parse(input);

            for (var i = 0; i < 10; i++)
            {
                area.Grow();
            }

            _output.WriteLine(area.ToString());

            Assert.Equal(1147, area.ResourceValue);
        }
    }
}
