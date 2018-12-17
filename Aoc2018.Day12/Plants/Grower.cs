using Aoc2018.Day12.Combinations;
using Aoc2018.Day12.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2018.Day12.Plants
{
    public class Grower
    {
        private readonly IEnumerable<Combination> _combinations;

        public Grower(IEnumerable<Combination> combinations)
        {
            _combinations = combinations ?? throw new ArgumentNullException(nameof(combinations));

            _combinations = _combinations.Where(c => c.ProducesNext);
        }

        public Pots Grow(string initialState, int numGenerations)
        {
            var pots = new Pots(0, initialState);

            for (var i = 0; i < numGenerations; i++)
            {
                pots = GrowGeneration(pots);
            }

            return pots;
        }

        private Pots GrowGeneration(Pots pots)
        {
            var plants = new StringBuilder();

            for (var i = -3; i < pots.HasPlant.Length + 3; i++)
            {
                var section = pots.GetSection(i);

                plants.Append(_combinations.Any(c => c.Mask == section) ? '#' : '.');
            }

            return PotsUtil.Normalize(pots.Offset - 3, plants.ToString());
        }
    }
}
