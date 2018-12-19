using System.Collections.Generic;

namespace Aoc2018.Day13.Tracks
{
    public class Cart
    {
        public Location Location { get; set; }

        public Directions Direction { get; set; }

        public int IntersectionCount { get; set; }

        public Cart(Location location, Directions direction)
        {
            Location = location;
            Direction = direction;
        }
    }

    public enum Directions
    {
        Down,  // "v"
        Up,    // "^"
        Left,  // "<"
        Right, // ">"
    }

    public static class DirectionsUtil
    {
        public static readonly IDictionary<Directions, char> ICONS = new Dictionary<Directions, char>()
        {
            { Directions.Down, 'v' },
            { Directions.Up, '^' },
            { Directions.Left, '<' },
            { Directions.Right, '>' },
        };
    }
}
