using Aoc2018.Day18.Areas;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day18.Common
{
    public static class InputParser
    {
        public static Area Parse(IEnumerable<string> input)
        {
            var lines = input.ToArray();

            var area = new Area(lines[0].Length, lines.Length);

            for (var y = 0; y < area.Height; y++)
            {
                for (var x = 0; x < area.Width; x++)
                {
                    switch (lines[y][x])
                    {
                        case '|':
                            area.SetLandType(x, y, LandType.Trees);
                            break;

                        case '#':
                            area.SetLandType(x, y, LandType.Lumberyard);
                            break;
                    }
                }
            }

            return area;
        }
    }
}
