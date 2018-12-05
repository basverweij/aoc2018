using System.Linq;

namespace Aoc2018.Day05.Common
{
    public static class Chemist
    {
        public static string ReactWithout(string polymer, char unitToRemove)
        {
            polymer = polymer
                .Replace(unitToRemove.ToString().ToLowerInvariant(), "")
                .Replace(unitToRemove.ToString().ToUpperInvariant(), "");

            return Reactor.React(polymer);
        }

        public static int FindShortestPolymerLength(string polymer)
        {
            return Enumerable
                .Range('a', 'z')
                .Select(u => ReactWithout(polymer, (char)u))
                .Min(p => p.Length);
        }
    }
}
