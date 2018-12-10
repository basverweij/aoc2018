using System;

namespace Aoc2018.Day10.Points
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int VelocityX { get; set; }

        public int VelocityY { get; set; }

        public Point(int x, int y, int velocityX, int velocityY)
        {
            X = x;
            Y = y;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;

            return point != null &&
                   X == point.X &&
                   Y == point.Y &&
                   VelocityX == point.VelocityX &&
                   VelocityY == point.VelocityY;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, VelocityX, VelocityY);
        }
    }
}
