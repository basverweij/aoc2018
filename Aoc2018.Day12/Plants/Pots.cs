using System;
using System.Linq;

namespace Aoc2018.Day12.Plants
{
    public class Pots
    {
        public long Offset { get; set; }

        public string HasPlant { get; set; }

        public Pots(long offset, string hasPlant)
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

        public override string ToString()
        {
            return $"{Offset: 000000;-000000}: {HasPlant} ({GetSumOfPotNumbers()})";
        }

        public int GetSectionMask(int index)
        {
            var l = HasPlant.Length;

            int m = 0;

            if (index - 2 >= 0 && index - 2 < l && HasPlant[index - 2] == '#')
            {
                m |= 16;
            }

            if (index - 1 >= 0 && index - 1 < l && HasPlant[index - 1] == '#')
            {
                m |= 8;
            }

            if (index >= 0 && index < l && HasPlant[index] == '#')
            {
                m |= 4;
            }

            if (index + 1 >= 0 && index + 1 < l && HasPlant[index + 1] == '#')
            {
                m |= 2;
            }

            if (index + 2 >= 0 && index + 2 < l && HasPlant[index + 2] == '#')
            {
                m |= 1;
            }

            return m;
        }

        public long GetSumOfPotNumbers()
        {
            return HasPlant
                .ToCharArray()
                .Select((c, i) => c == '#' ? i + Offset : 0)
                .Sum();
        }
    }
}
