using Aoc2018.Day15.Areas;
using Aoc2018.Day15.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day15.Common
{
    public static class InputParser
    {
        public static Area Parse(IEnumerable<string> input, int elfAttackPower = 3)
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
                            AddUnit(area, x, y, UnitTypes.Elf, elfAttackPower);
                            break;

                        case 'G':
                            AddUnit(area, x, y, UnitTypes.Goblin, 3);
                            break;

                        default:
                            throw new ArgumentException($"invalid character in input at ({x},{y}): '{lines[y][x]}'");
                    }
                }
            }

            return area;
        }

        private static void AddUnit(Area area, int x, int y, UnitTypes type, int attackPower)
        {
            var unit = new Unit(type, new Location(x, y), 200, attackPower);

            area.MoveUnit(unit, unit.Location);
        }
    }
}
