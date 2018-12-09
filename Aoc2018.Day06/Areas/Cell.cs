using System;

namespace Aoc2018.Day06.Areas
{
    public class Cell
    {
        public int Coordinate { get; set; }

        public int Distance { get; set; }

        public Cell(int coordinate, int distance)
        {
            Coordinate = coordinate;
            Distance = distance;
        }

        public override bool Equals(object obj)
        {
            var cell = obj as Cell;

            return cell != null &&
                   Coordinate == cell.Coordinate &&
                   Distance == cell.Distance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Coordinate, Distance);
        }
    }
}
