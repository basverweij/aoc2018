using Aoc2018.Day15.Common;
using Aoc2018.Day15.Games;
using Xunit;
using Xunit.Abstractions;

namespace Aoc2018.Day15.Tests.Games
{
    public class DefaultAttackStrategyTest
    {
        private readonly ITestOutputHelper _output;

        public DefaultAttackStrategyTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private static readonly string[][] inputs = new string[][]
        {
            new string[]
            {
                "#######",
                "#.G...#",
                "#...EG#",
                "#.#.#G#",
                "#..G#E#",
                "#.....#",
                "#######",
            },
            new string[]
            {
                "#######",
                "#G..#E#",
                "#E#E.E#",
                "#G.##.#",
                "#...#E#",
                "#...E.#",
                "#######",
            },
            new string[]
            {
                "#######",
                "#E..EG#",
                "#.#G.E#",
                "#E.##E#",
                "#G..#.#",
                "#..E#.#",
                "#######",
            },
            new string[]
            {
                "#######",
                "#E.G#.#",
                "#.#G..#",
                "#G.#.G#",
                "#G..#.#",
                "#...E.#",
                "#######",
            },
            new string[]
            {
                "#######",
                "#.E...#",
                "#.#..G#",
                "#.###.#",
                "#E#G#G#",
                "#...#G#",
                "#######",
            },
            new string[]
            {
                "#########",
                "#G......#",
                "#.E.#...#",
                "#..##..G#",
                "#...##..#",
                "#...#...#",
                "#.G...G.#",
                "#.....G.#",
                "#########",
            },
        };

        [Theory]
        [InlineData(0, 47, 27730)]
        [InlineData(1, 37, 36334)]
        [InlineData(2, 46, 39514)]
        [InlineData(3, 35, 27755)]
        [InlineData(4, 54, 28944)]
        [InlineData(5, 20, 18740)]
        public void Attacks(int index, int completeRounds, int score)
        {
            var area = InputParser.Parse(inputs[index]);

            var game = new Game(area, new DefaultMoveStrategy(), new DefaultAttackStrategy());

            for (var i = 0; i < completeRounds; i++)
            {
                Assert.True(game.Turn());

                _output.WriteLine($"After round {i + 1}:");
                _output.WriteLine(game.Area.ToString());
            }

            Assert.False(game.Turn());

            Assert.Equal(score, game.Score);
        }
    }
}
