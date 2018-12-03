using Aoc2018.Day03.Domain;
using Xunit;

namespace Aoc2018.Day03.Tests
{
    public class OverlapCalculatorTest
    {
        [Fact]
        public void GetOverlappingSquaresReturnsOverlap()
        {
            var squares = new Square[]
            {
                new Square(1, 1, 3, 4, 4),
                new Square(2, 3, 1, 4, 4),
                new Square(3, 5, 5, 2, 2),
                new Square(4, 3, 3, 2, 2),
            };

            Assert.Equal(4, OverlapCalculator.GetOverlappingSquares(8, squares));
        }
    }
}
