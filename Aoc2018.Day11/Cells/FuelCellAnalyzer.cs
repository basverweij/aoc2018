namespace Aoc2018.Day11.Cells
{
    public static class FuelCellAnalyzer
    {
        public static int PowerLevel(int gridSerialNumber, int x, int y)
        {
            var level = ((x + 10) * y) + gridSerialNumber;

            level *= (x + 10);

            level /= 100;

            return (level % 10) - 5;
        }
    }
}
