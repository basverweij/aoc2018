using System;

namespace Aoc2018.Core.Puzzles
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class PuzzleAttribute : Attribute
    {
        public PuzzleAttribute() { }
    }
}
