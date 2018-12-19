using System;

namespace Aoc2018.Day13.Tracks
{
    public sealed class OneCartRemainingException
        : Exception
    {
        public Location Location { get; }

        public OneCartRemainingException(Location location)
        {
            Location = location;
        }
    }
}