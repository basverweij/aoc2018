using System.Collections.Generic;

namespace Aoc2018.Day01
{
    public static class FrequencyParser
    {
        public static IEnumerable<int> Parse(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return int.Parse(line);
            }
        }
    }
}
