using Aoc2018.Day15.Units;
using System.Collections.Generic;

namespace Aoc2018.Day15.Common
{
    public static class UnitsUtil
    {
        public static IEnumerable<Location> LocationsInRange(Location target, int width, int height)
        {
            if (target.Y > 0)
            {
                yield return new Location(target.X, target.Y - 1); // top
            }

            if (target.X > 0)
            {
                yield return new Location(target.X - 1, target.Y); // left
            }

            if (target.X < width - 1)
            {
                yield return new Location(target.X + 1, target.Y); // right
            }

            if (target.Y < height - 1)
            {
                yield return new Location(target.X, target.Y + 1); // bottom
            }
        }
    }
}
