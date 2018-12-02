using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day02
{
    public static class ChecksumCalculator
    {
        public static int CalculateChecksum(IEnumerable<string> ids)
        {
            var exactlyTwo = 0;
            var exactlyThree = 0;

            foreach (var id in ids)
            {
                var counts = CharacterCounter.CountCharacters(id);

                if (counts.Any(c => c == 2))
                {
                    exactlyTwo++;
                }

                if (counts.Any(c => c == 3))
                {
                    exactlyThree++;
                }
            }

            return exactlyTwo * exactlyThree;
        }
    }
}
