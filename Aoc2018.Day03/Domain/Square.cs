using System;

namespace Aoc2018.Day03.Domain
{
    public class Square
    {
        public Square(int id, int left, int top, int width, int height)
        {
            Id = id;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public int Id { get; }

        public int Left { get; }

        public int Top { get; }

        public int Width { get; }

        public int Height { get; }

        public override bool Equals(object obj)
        {
            var square = obj as Square;

            return square != null &&
                   Id == square.Id &&
                   Left == square.Left &&
                   Top == square.Top &&
                   Width == square.Width &&
                   Height == square.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Left, Top, Width, Height);
        }
    }
}
