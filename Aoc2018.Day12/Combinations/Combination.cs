using System;

namespace Aoc2018.Day12.Combinations
{
    public class Combination
    {
        public string Mask { get; set; }

        public bool ProducesNext { get; set; }

        public Combination(string mask, bool producesNext)
        {
            Mask = mask;
            ProducesNext = producesNext;
        }

        public override bool Equals(object obj)
        {
            return obj is Combination combination &&
                Mask == combination.Mask &&
                ProducesNext == combination.ProducesNext;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Mask, ProducesNext);
        }
    }
}
