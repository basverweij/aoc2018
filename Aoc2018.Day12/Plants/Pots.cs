using System;
using System.Linq;

namespace Aoc2018.Day12.Plants
{
    public class Pots
    {
        public int Offset { get; set; }

        public string HasPlant { get; set; }

        public Pots(int offset, string hasPlant)
        {
            Offset = offset;
            HasPlant = hasPlant;
        }

        public override bool Equals(object obj)
        {
            return obj is Pots pots &&
                Offset == pots.Offset &&
                HasPlant == pots.HasPlant;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Offset, HasPlant);
        }

        public string GetSection(int index)
        {
            return ("....." + HasPlant + ".....").Substring(index + 3, 5);
        }

        public int GetSumOfPotNumbers()
        {
            return HasPlant
                .ToCharArray()
                .Select((c, i) => c == '#' ? i + Offset : 0)
                .Sum();
        }
    }
}
