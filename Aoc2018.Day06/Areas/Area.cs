namespace Aoc2018.Day06.Areas
{
    public class Area
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Area(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new Cell[Width, Height];
        }

        private readonly Cell[,] _cells;

        public Cell GetCell(int x, int y)
        {
            return _cells[x, y];
        }

        public void SetCell(int x, int y, int coordinate, int distance)
        {
            var cell = _cells[x, y];
            if (cell != null)
            {
                cell.Coordinate = coordinate;
                cell.Distance = distance;

                return;
            }

            cell = new Cell(coordinate, distance);
            _cells[x, y] = cell;
        }
    }
}
