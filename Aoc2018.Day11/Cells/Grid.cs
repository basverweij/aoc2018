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

        public (int, int, int) FindLargestTotalPower()
        {
            var max = (x: 0, y: 0, totalPower: int.MinValue);

            for (var y = 0; y < _height - 2; y++)
            {
                for (var x = 0; x < _width - 2; x++)
                {
                    var totalPower =
                        _cells[x, y] + _cells[x + 1, y] + _cells[x + 2, y] +
                        _cells[x, y + 1] + _cells[x + 1, y + 1] + _cells[x + 2, y + 1] +
                        _cells[x, y + 2] + _cells[x + 1, y + 2] + _cells[x + 2, y + 2];

                    if (totalPower > max.totalPower)
                    {
                        max = (x + 1, y + 1, totalPower);
                    }
                }
            }

            return max;
        }
    }
}
