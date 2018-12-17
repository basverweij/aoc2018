using Aoc2018.Day12.Combinations;
using Aoc2018.Day12.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day12.Plants
{
    public class Grower
    {
        private readonly IEnumerable<Combination> _combinations;

        public Grower(IEnumerable<Combination> combinations)
        {
            _combinations = combinations ?? throw new ArgumentNullException(nameof(combinations));
        }

        public Pots Grow(string initialState, long numGenerations)
        {
            var combinations = new char[32];

            for (var i = 0; i < combinations.Length; i++)
            {
                combinations[i] = '.';
            }

            foreach (var c in _combinations.Where(c => c.ProducesNext))
            {
                combinations[c.GetMask()] = '#';
            }

            var pots = new Pots(0, initialState);

            var lastPots = pots;

            for (long i = 0; i < numGenerations; i++)
            {
                pots = GrowGeneration(pots, combinations);

                if (lastPots.HasPlant == pots.HasPlant)
                {
                    // only index will change
                    return new Pots(
                        pots.Offset + (pots.Offset - lastPots.Offset) * (numGenerations - i),
                        pots.HasPlant);
                }

                lastPots = pots;
            }

            return pots;
        }

        private Pots GrowGeneration(Pots pots, char[] combinations)
        {
            var plants = new char[pots.HasPlant.Length + 6];

            for (var i = -3; i < pots.HasPlant.Length + 3; i++)
            {
                var sectionMask = pots.GetSectionMask(i);

                plants[i + 3] = combinations[sectionMask];
            }

            return PotsUtil.Normalize(pots.Offset - 3, new string(plants));
        }
    }
}
