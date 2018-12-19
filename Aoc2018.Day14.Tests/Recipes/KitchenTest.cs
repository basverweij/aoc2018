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

        [Theory]
        [InlineData(new int[] { 5, 1, 5, 8, 9 }, 9)]
        [InlineData(new int[] { 0, 1, 2, 4, 5 }, 5)]
        [InlineData(new int[] { 9, 2, 5, 1, 0 }, 18)]
        [InlineData(new int[] { 5, 9, 4, 1, 4 }, 2018)]
        public void NumRecipesBeforeEndsWith(int[] scores, int expected)
        {
            var sut = new Kitchen();

            int num;

            while ((num = sut.NumRecipesBeforeEndsWith(scores)) < 0)
            {
                sut.Cook();
            }

            Assert.Equal(expected, num);
        }
    }
}
