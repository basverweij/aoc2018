namespace Aoc2018.Day11.Cells
{
    public class Grid
    {
        private readonly int _width;

        private readonly int _height;

        private int[,] _cells;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void Fill(int gridSerialNumber)
        {
            _cells = new int[_width, _height];

            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    _cells[x, y] = FuelCellAnalyzer.PowerLevel(gridSerialNumber, x + 1, y + 1);
                }
            }
        }

        public (int, int, int, int) FindLargestTotalPower()
        {
            var max = (x: 0, y: 0, size: 0, totalPower: int.MinValue);

            for (var size = 300; size > 0; size--)
            {
                if (max.totalPower > 4 * size * size)
                {
                    break;
                }

                for (var y = 0; y < _height - (size - 1); y++)
                {
                    for (var x = 0; x < _width - (size - 1); x++)
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
            var totalPower = 0;

            for (var j = y; j < y + size; j++)
            {
                for (var i = x; i < x + size; i++)
                {
                    totalPower += _cells[i, j];
                }
            }

            return totalPower;
        }
    }
}
