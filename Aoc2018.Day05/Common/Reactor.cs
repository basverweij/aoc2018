using System.Text;

namespace Aoc2018.Day05.Common
{
    public static class Reactor
    {
        public static string React(string polymer)
        {
            var lastLength = -1;

            while (lastLength != polymer.Length)
            {
                lastLength = polymer.Length;
                polymer = Reduce(polymer);
            }

            return polymer;
        }

        public static string Reduce(string polymer)
        {
            var result = new StringBuilder();

            var units = polymer.ToCharArray();

            var pos = 0;

            for (var i = 0; i < polymer.Length - 1; i++)
            {
                if (Triggered(units[i], units[i + 1]))
                {
                    if (i > pos)
                    {
                        result.Append(polymer.Substring(pos, i - pos));
                    }

                    pos = i + 2;
                    i = i + 1;
                }
            }

            if (polymer.Length > pos)
            {
                result.Append(polymer.Substring(pos, polymer.Length - pos));
            }

            return result.ToString();
        }

        public static bool Triggered(char unit1, char unit2)
        {
            return
                (unit1 - unit2 == 0x20) ||
                (unit2 - unit1 == 0x20);
        }
    }
}
