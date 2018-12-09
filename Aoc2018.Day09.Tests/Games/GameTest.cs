using Aoc2018.Day09.Games;
using Xunit;

namespace Aoc2018.Day09.Tests.Games
{
    public class GameTest
    {
        [Fact]
        public void HighScores()
        {
            Assert.Equal(32, Game.HighestScore(9, 25));

            Assert.Equal(8317, Game.HighestScore(10, 1618));

            Assert.Equal(146373, Game.HighestScore(13, 7999));

            Assert.Equal(2764, Game.HighestScore(17, 1104));

            Assert.Equal(54718, Game.HighestScore(21, 6111));

            Assert.Equal(37305, Game.HighestScore(30, 5807));
        }
    }
}
