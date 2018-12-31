using Aoc2018.Day15.Areas;
using Aoc2018.Day15.Common;
using Aoc2018.Day15.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day15.Games
{
    public class DefaultMoveStrategy :
        IMoveStrategy
    {
        public Location? Move(Unit unit, Area area, IEnumerable<Location> targets)
        {
            if (targets
                .Intersect(UnitsUtil.LocationsInRange(unit.Location, area.Width, area.Height))
                .Any())
            {
                // don't move if already adjacent to a target
                return null;
            }

            var inRangeLocations = targets
                .SelectMany(l => UnitsUtil.LocationsInRange(l, area.Width, area.Height))
                .Distinct()
                .Where(l => !area.IsWall(l.X, l.Y)) // not a wall
                .Where(l => area.GetUnit(l.X, l.Y) == null) // not a unit
                .ToArray();

            // flood fill area to determine path distances
            var pathDistances = new int[area.Width, area.Height];

            Fill(area, unit.Location, pathDistances, unit.Location.X, unit.Location.Y, 0);

            // determine leading target in range location
            var distances = inRangeLocations
                .Select(l => pathDistances[l.X, l.Y])
                .ToArray();

            int minDistance;

            try
            {
                minDistance = distances
                    .Where(d => d > 0)
                    .Min();
            }
            catch (InvalidOperationException)
            {
                return null;
                //throw new NoTargetsReachableException($"from: {unit}");
            }

            var leadingInRangeLocation = inRangeLocations
                .Where((_, i) => distances[i] == minDistance)
                .OrderBy(l => l.Y)
                .ThenBy(l => l.X)
                .First();

            // determine leading shortest path
            pathDistances = new int[area.Width, area.Height];

            Fill(area, leadingInRangeLocation, pathDistances, leadingInRangeLocation.X, leadingInRangeLocation.Y, 1);

            return UnitsUtil.LocationsInRange(unit.Location, area.Width, area.Height)
                .Where(l => pathDistances[l.X, l.Y] == minDistance) // shortest paths
                .OrderBy(l => l.Y) // resolve ties by reading order
                .ThenBy(l => l.X) // resolve ties by reading order
                .FirstOrDefault();
        }

        private static void Fill(Area area, Location source, int[,] pathDistances, int x, int y, int distance)
        {
            if (area.IsWall(x, y))
            {
                pathDistances[x, y] = int.MaxValue;
                return;
            }

            var unit = area.GetUnit(x, y);

            if (unit != null)
            {
                pathDistances[x, y] = int.MaxValue;

                if (!unit.Location.Equals(source))
                {
                    return;
                }
            }

            if ((pathDistances[x, y] != int.MaxValue) &&
                ((pathDistances[x, y] == 0) ||
                (pathDistances[x, y] > distance)))
            {
                pathDistances[x, y] = distance;
            }
            else if (pathDistances[x, y] < distance)
            {
                // cell to fill already has a shorter distance, so no need to fill further
                return;
            }

            if (x > 0)
            {
                // fill left
                Fill(area, source, pathDistances, x - 1, y, distance + 1);
            }

            if (x < area.Width - 1)
            {
                // fill right
                Fill(area, source, pathDistances, x + 1, y, distance + 1);
            }

            if (y > 0)
            {
                // fill top
                Fill(area, source, pathDistances, x, y - 1, distance + 1);
            }

            if (y < area.Height - 1)
            {
                // fill bottom
                Fill(area, source, pathDistances, x, y + 1, distance + 1);
            }
        }
    }
}
