using System;

namespace Aoc2018.Day06.Coordinates
{
    public class Coordinate
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Coordinate(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var coordinate = obj as Coordinate;

            return coordinate != null &&
                   Id == coordinate.Id &&
                   X == coordinate.X &&
                   Y == coordinate.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, X, Y);
        }
    }
}
