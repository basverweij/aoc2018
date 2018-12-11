using Aoc2018.Day11.Cells;
using Xunit;

namespace Aoc2018.Day11.Tests.Cells
{
    public class GridTest
    {
        [Fact]
        void FillsGrid()
        {
            var sut = new Grid(300, 300);

            sut.Fill(18);
        }

        [Theory]
        [InlineData(18, 33, 45, 29)]
        [InlineData(42, 21, 61, 30)]
        void FindsLargestTotalPower(int gridSerialNumber, int expectedX, int expectedY, int expectedTotalPower)
        {
            var sut = new Grid(300, 300);

            sut.Fill(gridSerialNumber);

            var largest = sut.FindLargestTotalPower();

            Assert.Equal((expectedX, expectedY, expectedTotalPower), largest);
        }
    }
}
