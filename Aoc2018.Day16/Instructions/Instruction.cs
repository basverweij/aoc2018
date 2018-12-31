using System;

namespace Aoc2018.Day16.Instructions
{
    public class Instruction
    {
        public int Opcode { get; }

        public int A { get; }

        public int B { get; }

        public int C { get; }

        public Instruction(int opcode, int a, int b, int c)
        {
            Opcode = opcode;
            A = a;
            B = b;
            C = c;
        }

        public override bool Equals(object obj)
        {
            return obj is Instruction instruction &&
                Opcode == instruction.Opcode &&
                A == instruction.A &&
                B == instruction.B &&
                C == instruction.C;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Opcode, A, B, C);
        }
    }

    public enum Opcodes
    {
        AddR, // reg A + reg B -> reg C
        AddI, // reg A + val B -> reg C
        MulR, // reg A * reg B -> reg C
        MulI, // reg A * val B -> reg C
        BanR, // reg A & reg B -> reg C
        BanI, // reg A & val B -> reg C
        BorR, // reg A | reg B -> reg C
        BorI, // reg A | val B -> reg C
        SetR, // reg A         -> reg C
        SetI, // val A         -> reg C
        GtIR, // val A > reg B -> reg C = 1, else reg C = 0
        GtRI, // reg A > val B -> reg C = 1, else reg C = 0
        GtRR, // reg A > reg B -> reg C = 1, else reg C = 0
        EqIR, // val A = reg B -> reg C = 1, else reg C = 0
        EqRI, // reg A = val B -> reg C = 1, else reg C = 0
        EqRR, // reg A = reg B -> reg C = 1, else reg C = 0
    }
}
