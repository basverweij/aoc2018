using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Aoc2018.Core.Puzzles
{
    public static class PuzzleUtil
    {
        public static IEnumerable<Task> GetPuzzles()
        {
            var path = Path.GetDirectoryName(
                Assembly
                    .GetExecutingAssembly()
                    .Location);

            return Directory.GetFiles(path, "Aoc2018.Day*.dll")
                .Select(f => Assembly.LoadFile(f))
                .SelectMany(a => a.GetTypes())
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.NonPublic))
                .Where(m => m.GetCustomAttributes(typeof(PuzzleAttribute), false).Any())
                .Select(m => new Task(() => m.Invoke(null, null)));
        }
    }
}
