using Aoc2018.Day12.Plants;

namespace Aoc2018.Day12.Common
{
    public static class PotsUtil
    {
        public static Pots Normalize(long offset, string hasPlant)
        {
            var firstPlant = hasPlant.IndexOf('#');

            var lastPlant = hasPlant.LastIndexOf('#');

            return new Pots(
                offset + firstPlant,
                hasPlant.Substring(firstPlant, lastPlant - firstPlant + 1));
        }
    }
}
