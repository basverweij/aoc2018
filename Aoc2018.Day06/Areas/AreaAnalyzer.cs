using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day06.Areas
{
    public static class AreaAnalyzer
    {
        public static int LargestFiniteArea(Area area)
        {
            // exclude coordinates that have infinite areas (e.g. are at the borders)
            var infiniteCoordinates = new HashSet<int>();
            infiniteCoordinates.Add(-1); // exclude ties as well

            for (var x = 0; x < area.Width; x++)
            {
                infiniteCoordinates.Add(area.GetCell(x, 0).Coordinate);
                infiniteCoordinates.Add(area.GetCell(x, area.Height - 1).Coordinate);
            }

            for (var y = 0; y < area.Height; y++)
            {
                infiniteCoordinates.Add(area.GetCell(0, y).Coordinate);
                infiniteCoordinates.Add(area.GetCell(area.Width - 1, y).Coordinate);
            }

            // count all areas of the other coordinates
            var areaSize = new Dictionary<int, int>();

            for (var x = 0; x < area.Width; x++)
            {
                for (var y = 0; y < area.Height; y++)
                {
                    var c = area.GetCell(x, y);

                    if (infiniteCoordinates.Contains(c.Coordinate))
                    {
                        continue;
                    }

                    if (areaSize.ContainsKey(c.Coordinate))
                    {
                        areaSize[c.Coordinate]++;
                    }
                    else
                    {
                        areaSize[c.Coordinate] = 1;
                    }
                }
            }

            var maxSize = areaSize
                .Max(kvp => kvp.Value);

            return maxSize;
        }
    }
}
