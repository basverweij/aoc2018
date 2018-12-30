using Aoc2018.Day15.Areas;
using Aoc2018.Day15.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day15.Common
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
                        case '.':
                            break;

                        case '#':
                            area.SetWall(x, y);
                            break;

                        case 'E':
                            AddUnit(area, x, y, UnitTypes.Elf);
                            break;

                        case 'G':
                            AddUnit(area, x, y, UnitTypes.Goblin);
                            break;

                        default:
                            throw new ArgumentException($"invalid character in input at ({x},{y}): '{lines[y][x]}'");
                    }
                }
            }

            return area;
        }

        private static void AddUnit(Area area, int x, int y, UnitTypes type)
        {
            var unit = new Unit(type, new Location(x, y), 200, 3);

            area.MoveUnit(unit, unit.Location);
        }
    }
}
