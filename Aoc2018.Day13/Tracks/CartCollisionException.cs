using System;

namespace Aoc2018.Day13.Tracks
{
    public sealed class CartCollisionException : Exception
    {
        public Location Location { get; set; }

        public CartCollisionException(Location location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }
    }
}
