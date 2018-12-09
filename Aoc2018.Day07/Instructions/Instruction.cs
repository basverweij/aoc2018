using System;

namespace Aoc2018.Day07.Instructions
{
    public class Instruction
    {
        public char RequiredStep { get; set; }

        public char ForStep { get; set; }

        public Instruction(char requiredStep, char forStep)
        {
            RequiredStep = requiredStep;
            ForStep = forStep;
        }

        public override bool Equals(object obj)
        {
            var instruction = obj as Instruction;

            return instruction != null &&
                   RequiredStep == instruction.RequiredStep &&
                   ForStep == instruction.ForStep;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RequiredStep, ForStep);
        }
    }
}
