using Aoc2018.Day14.Recipes;
using Xunit;

namespace Aoc2018.Day14.Tests.Recipes
{
    public class KitchenTest
    {
        [Theory]
        [InlineData(9, "5158916779")]
        [InlineData(5, "0124515891")]
        [InlineData(18, "9251071085")]
        [InlineData(2018, "5941429882")]
        public void Cooks(int num, string expected)
        {
            var sut = new Kitchen();

            while (sut.Cook() < num + 10) { }

            Assert.Equal(expected, sut.Recipes(num, 10));
        }
    }
}
