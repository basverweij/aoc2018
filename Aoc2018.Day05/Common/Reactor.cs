using System.Text;

namespace Aoc2018.Day05.Common
{
    public static class Reactor
    {
        public static string React(string polymer)
        {
            return Reduce(polymer);
        }

        public static string Reduce(string polymer)
        {
            var units = polymer.ToCharArray();

            var first = new Unit(units[0], null);

            var current = first;

            for (var i = 1; i < units.Length; i++)
            {
                current = new Unit(units[i], current);
            }

            current = first;

            while (current?.Next != null)
            {
                if (!Triggered(current.Char, current.Next.Char))
                {
                    // no reaction: move to the next unit
                    current = current.Next;

                    continue;
                }

                if (current == first)
                {
                    // move the first unit after the two reacting units
                    first = current.Next.Next;

                    if (first != null)
                    {
                        first.Previous = null;
                    }

                    // update current to the new first unit
                    current = first;

                    continue;
                }

                // remove the current and next units
                current.Previous.Next = current.Next.Next;

                if (current.Next.Next != null)
                {
                    current.Next.Next.Previous = current.Previous;
                }

                // set current to the previous unit
                current = current.Previous;
            }

            var result = new StringBuilder();

            for (current = first; current != null; current = current.Next)
            {
                result.Append(current.Char);
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
