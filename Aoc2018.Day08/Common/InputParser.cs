using System.Linq;

namespace Aoc2018.Day08.Common
{
    public static class InputParser
    {
        public static int[] Parse(string input)
        {
            return input
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }
    }
}
