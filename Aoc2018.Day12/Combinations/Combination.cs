using System;

namespace Aoc2018.Day12.Combinations
{
    public class Combination
    {
        public string Section { get; set; }

        public bool ProducesNext { get; set; }

        public Combination(string mask, bool producesNext)
        {
            Section = mask;
            ProducesNext = producesNext;
        }

        public override bool Equals(object obj)
        {
            return obj is Combination combination &&
                Section == combination.Section &&
                ProducesNext == combination.ProducesNext;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Section, ProducesNext);
        }

        public int GetMask()
        {
            return Convert.ToInt32(
                Section
                    .Replace('.', '0')
                    .Replace('#', '1'), 
                2);
        }
    }
}
