using Aoc2018.Core.Puzzles;
using System.Diagnostics;

namespace Aoc2018.Runner
{
    static class Program
    {
        static void Main(string[] args)
        {
            var puzzles = PuzzleUtil.GetPuzzles();

            foreach (var puzzle in puzzles)
            {
                var sw = new Stopwatch();
                sw.Start();

                puzzle.RunSynchronously();

                sw.Stop();

                System.Console.WriteLine($"-- {sw.Elapsed}");
            }
        }
    }
}
