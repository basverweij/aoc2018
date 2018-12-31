using Aoc2018.Day15.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2018.Day15.Areas
{
    public class Area
    {
        public int Width { get; }

        public int Height { get; }

        private bool[,] _walls;

        private Unit[,] _units;

        public Area(int width, int height)
        {
            Width = width;
            Height = height;

            _walls = new bool[Width, Height];
            _units = new Unit[Width, Height];
        }

        public void SetWall(int x, int y)
        {
            _walls[x, y] = true;
        }

        public bool IsWall(int x, int y) => _walls[x, y];

        public void MoveUnit(Unit unit, Location to)
        {
            if (GetUnit(to.X, to.Y) != null)
            {
                throw new ArgumentException($"new locations already contains a unit: {to}", nameof(to));
            }

            _units[unit.Location.X, unit.Location.Y] = null;

            unit.Location = to;

            _units[unit.Location.X, unit.Location.Y] = unit;
        }

        public Unit GetUnit(int x, int y)
        {
            var unit = _units[x, y];

            if ((unit == null) ||
                !unit.IsAlive)
            {
                return null;
            }

            return unit;
        }

        public IEnumerable<Unit> GetUnits()
        {
            return Enumerable
                .Range(0, Height)
                .SelectMany(y => Enumerable
                    .Range(0, Width)
                    .Select(x => GetUnit(x, y))
                    .Where(u => u != null));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var row = new char[Width];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    row[x] = _walls[x, y] ?
                        '#' :
                        (GetUnit(x, y)?.UnitType.ToString()[0] ?? '.');
                }

                sb.AppendLine(new string(row));
            }

            return sb.ToString();
        }
    }
}
