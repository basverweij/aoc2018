using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day01
{
    public static class FrequencyCalibrator
    {
        public static int CalculateFrequency(IEnumerable<int> frequencies)
        {
            return frequencies.Sum();
        }

        public static int GetFirstDuplicateFrequency(IEnumerable<int> frequencies)
        {
            var results = new HashSet<int>();

            var result = 0;

            while (true)
            {
                foreach (var freq in frequencies)
                {
                    // add current frequency first
                    results.Add(result);

                    result += freq;

                    if (results.Contains(result))
                    {
                        return result;
                    }
                }
            }
        }
    }
}
