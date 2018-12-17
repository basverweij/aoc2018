using Aoc2018.Day12.Plants;
using Xunit;

namespace Aoc2018.Day12.Tests.Plants
{
    public class PotsTests
    {
        [Fact]
        public void GetSection()
        {
            var pots = new Pots(-3, ".#....##....#####...#######....#.#..##.");

            Assert.Equal(2, pots.GetSectionMask(0));
            Assert.Equal(24, pots.GetSectionMask(38));
        }

        [Fact]
        public void CalculatesCorrectSumOfPotNumbers()
        {
            var pots = new Pots(-2, "#....##....#####...#######....#.#..##");

            Assert.Equal(325, pots.GetSumOfPotNumbers());
        }
    }
}
