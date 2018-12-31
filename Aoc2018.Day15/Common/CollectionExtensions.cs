using System.Collections.Generic;

namespace Aoc2018.Day15.Common
{
    public static class CollectionExtensions
    {
        public static void AddAll<T>(this ICollection<T> c, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                c.Add(item);
            }
        }
    }
}
