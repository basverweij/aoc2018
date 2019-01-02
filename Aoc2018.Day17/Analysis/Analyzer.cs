using Aoc2018.Day17.Scans;
using System;

namespace Aoc2018.Day17.Analysis
{
    public static class Analyzer
    {
        public static int GetReachableWaterCellsCount(Scan scan)
        {
            if (scan.WaterCellsCount > 0)
            {
                throw new ArgumentException("scan must not contain any water cells", nameof(scan));
            }

            scan.AddWater(500);

            return scan.WaterCellsCount;
        }
    }
}
