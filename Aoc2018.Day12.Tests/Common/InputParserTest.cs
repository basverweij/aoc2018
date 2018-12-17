using Aoc2018.Day12.Combinations;
using Aoc2018.Day12.Common;
using Xunit;

namespace Aoc2018.Day12.Tests.Common
{
    public class InputParserTest
    {
        [Fact]
        public void ParseInput()
        {
            var input = new string[]
            {
                "...## => #",
                "..#.. => #",
                ".#... => #",
                ".#.#. => #",
                ".#.## => #",
                ".##.. => #",
                ".#### => #",
                "#.#.# => #",
                "#.### => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #",
            };

            var expected = new Combination[]
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

            Assert.Equal(expected, InputParser.Parse(input));
        }
    }
}
