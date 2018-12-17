using Aoc2018.Day12.Combinations;
using Aoc2018.Day12.Plants;
using Xunit;

namespace Aoc2018.Day12.Tests.Plants
{
    public class GrowerTest
    {
        [Fact]
        public void GrowerGrowsGenerations()
        {
            var combinations = new Combination[]
            {
                new Combination("...##", true),
                new Combination("..#..", true),
                new Combination(".#...", true),
                new Combination(".#.#.", true),
                new Combination(".#.##", true),
                new Combination(".##..", true),
                new Combination(".####", true),
                new Combination("#.#.#", true),
                new Combination("#.###", true),
                new Combination("##.#.", true),
                new Combination("##.##", true),
                new Combination("###..", true),
                new Combination("###.#", true),
                new Combination("####.", true),
            };

            var sut = new Grower(combinations);

            var expected = new Pots(-2, "#....##....#####...#######....#.#..##");

            Assert.Equal(expected, sut.Grow("#..#.#..##......###...###", 20));
        }
    }
}
