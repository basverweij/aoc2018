using Aoc2018.Day11.Cells;
using Xunit;

namespace Aoc2018.Day11.Tests.Cells
{
    public class FuelCellAnalyzerTest
    {
        //[Theory]
        //[InlineData(8, 3, 5, 4)]
        //[InlineData(57, 122, 79, -5)]
        //[InlineData(39, 217, 196, 0)]
        //[InlineData(71, 101, 153, 4)]
        void PowerLevelIsCorrect(int gridSerialNumber, int x, int y, int expected)
        {
            Assert.Equal(expected, FuelCellAnalyzer.PowerLevel(gridSerialNumber, x, y));
        }
    }
}
