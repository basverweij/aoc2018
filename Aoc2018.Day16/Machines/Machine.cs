using Aoc2018.Day16.Instructions;
using System;
using System.Linq;

namespace Aoc2018.Day16.Machines
{
    public class Machine
    {
        public int[] Registers { get; } = new int[4];

        public Machine(params int[] registers)
        {
            if (registers != null &&
                registers.Any())
            {
                Array.Copy(registers, Registers, Registers.Length);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Machine machine &&
                Registers.SequenceEqual(machine.Registers);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Registers);
        }

        public override string ToString()
        {
            return $"[{Registers[0]}, {Registers[1]}, {Registers[2]}, {Registers[3]}]";
        }

        public void Execute(Opcodes opcode, int a, int b, int c)
        {
            switch (opcode)
            {
                case Opcodes.AddI:
                    Registers[c] = Registers[a] + b;
                    break;

                case Opcodes.AddR:
                    Registers[c] = Registers[a] + Registers[b];
                    break;

                case Opcodes.BanI:
                    Registers[c] = Registers[a] & b;
                    break;

                case Opcodes.BanR:
                    Registers[c] = Registers[a] & Registers[b];
                    break;

                case Opcodes.BorI:
                    Registers[c] = Registers[a] | b;
                    break;

                case Opcodes.BorR:
                    Registers[c] = Registers[a] | Registers[b];
                    break;

                case Opcodes.EqIR:
                    Registers[c] = a == Registers[b] ? 1 : 0;
                    break;

                case Opcodes.EqRI:
                    Registers[c] = Registers[a] == b ? 1 : 0;
                    break;

                case Opcodes.EqRR:
                    Registers[c] = Registers[a] == Registers[b] ? 1 : 0;
                    break;

                case Opcodes.GtIR:
                    Registers[c] = a > Registers[b] ? 1 : 0;
                    break;

                case Opcodes.GtRI:
                    Registers[c] = Registers[a] > b ? 1 : 0;
                    break;

                case Opcodes.GtRR:
                    Registers[c] = Registers[a] > Registers[b] ? 1 : 0;
                    break;

                case Opcodes.MulI:
                    Registers[c] = Registers[a] * b;
                    break;

                case Opcodes.MulR:
                    Registers[c] = Registers[a] * Registers[b];
                    break;

                case Opcodes.SetI:
                    Registers[c] = a;
                    break;

                case Opcodes.SetR:
                    Registers[c] = Registers[a];
                    break;
            }
        }
    }
}
