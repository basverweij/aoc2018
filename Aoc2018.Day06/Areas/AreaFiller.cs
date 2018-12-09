using Aoc2018.Day06.Coordinates;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day06.Areas
{
    public static class AreaFiller
    {
        public static Area Fill(IEnumerable<Coordinate> coordinates)
        {
            // normalize all coordinates to (0,0)
            var minX = coordinates.Min(c => c.X);
            var minY = coordinates.Min(c => c.Y);

            var normalizedCoordinates = coordinates
                .Select(c => new Coordinate(c.Id, c.X - minX, c.Y - minY));

            var width = normalizedCoordinates.Max(c => c.X) + 1;
            var height = normalizedCoordinates.Max(c => c.Y) + 1;

            // create the area
            var area = new Area(width, height);

            // fill the area for each of the coordinates
            foreach (var c in normalizedCoordinates)
            {
                FillForCoordinate(area, c);
            }

            return area;
        }

        private static void FillForCoordinate(Area area, Coordinate coordinate)
        {
            for (var y = 0; y < area.Height; y++)
            {
                var rowDistance = Abs(coordinate.Y, y);

                for (var x = 0; x < area.Width; x++)
                {
                    var cellDistance = rowDistance + Abs(coordinate.X, x);

                    var cell = area.GetCell(x, y);
                    if (cell == null)
                    {
                        // not filled yet
                        area.SetCell(x, y, coordinate.Id, cellDistance);

                        continue;
                    }

                    if (cell.Distance < cellDistance)
                    {
                        // other coordinate's distance is smaller
                        continue;
                    }
                    else if (cell.Distance == cellDistance)
                    {
                        // tie -> remove coordinate from cell
                        cell.Coordinate = -1;

                        continue;
                    }

                    // this coordinate is closer -> update cell
                    cell.Coordinate = coordinate.Id;
                    cell.Distance = cellDistance;
                }
            }
        }

        private static int Abs(int a, int b)
        {
            return a > b ? a - b : b - a;
        }
    }
}