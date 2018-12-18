using Aoc2018.Day11.Tables;

namespace Aoc2018.Day11.Cells
{
    public class Grid
    {
        private readonly SummedAreaTable _cells;

        public Grid(int width, int height)
        {
            _cells = new SummedAreaTable(width, height);
        }

        public void Fill(int gridSerialNumber)
        {
            _cells.Fill((x, y) => FuelCellAnalyzer.PowerLevel(gridSerialNumber, x + 1, y + 1));
        }

        public (int, int, int, int) FindLargestTotalPower(int fromSize, int toSize)
        {
            var max = (x: 0, y: 0, size: 0, totalPower: int.MinValue);

            for (var size = fromSize; size <= toSize; size++)
            {
                for (var x = 0; x < _cells.Width - (size - 1); x++)
                {
                    for (var y = 0; y < _cells.Height - (size - 1); y++)
                    {
                        var totalPower = TotalPower(x, y, size);

                        if (totalPower > max.totalPower)
                        {
                            max = (x + 1, y + 1, size, totalPower);
                        }
                    }
                }
            }

            return max;
        }

        private int TotalPower(int x, int y, int size)
        {
            return _cells.GetAreaSum(x, y, x + size - 1, y + size - 1);
        }
    }
}
