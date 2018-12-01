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
    }
}
