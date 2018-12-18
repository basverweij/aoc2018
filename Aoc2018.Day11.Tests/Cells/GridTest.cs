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
        void FindsLargestTotalPowerWithSize3(int gridSerialNumber, int expectedX, int expectedY, int expectedTotalPower)
        {
            var sut = new Grid(300, 300);

            sut.Fill(gridSerialNumber);

            var largest = sut.FindLargestTotalPower(3, 3);

            Assert.Equal((expectedX, expectedY, 3, expectedTotalPower), largest);
        }

        [Theory]
        [InlineData(18, 90, 269, 16, 113)]
        [InlineData(42, 232, 251, 12, 119)]
        void FindsLargestTotalPower(int gridSerialNumber, int expectedX, int expectedY, int expectedSize, int expectedTotalPower)
        {
            var sut = new Grid(300, 300);

            sut.Fill(gridSerialNumber);

            var largest = sut.FindLargestTotalPower(1, 300);

            Assert.Equal((expectedX, expectedY, expectedSize, expectedTotalPower), largest);
        }
    }
}
