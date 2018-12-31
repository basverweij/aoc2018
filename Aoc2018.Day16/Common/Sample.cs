using Aoc2018.Day16.Instructions;
using Aoc2018.Day16.Machines;
using System;

namespace Aoc2018.Day16.Common
{
    public class Sample
    {
        public Machine Before { get; }

        public Instruction Instruction { get; }

        public Machine After { get; }

        public Sample(Machine before, Instruction instruction, Machine after)
        {
            Before = before ?? throw new ArgumentNullException(nameof(before));
            Instruction = instruction ?? throw new ArgumentNullException(nameof(instruction));
            After = after ?? throw new ArgumentNullException(nameof(after));
        }
    }
}
