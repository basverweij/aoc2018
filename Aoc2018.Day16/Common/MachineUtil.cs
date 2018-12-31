using Aoc2018.Day16.Instructions;
using Aoc2018.Day16.Machines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day16.Common
{
    public static class MachineUtil
    {
        public static IEnumerable<Opcodes> AllOpcodes()
        {
            return Enum
                .GetValues(typeof(Opcodes))
                .Cast<Opcodes>();
        }

        public static IEnumerable<Opcodes> FindMatchingOpcodes(Machine before, int a, int b, int c, Machine after)
        {
            foreach (var opcode in AllOpcodes())
            {
                var m = new Machine(before.Registers);

                m.Execute(opcode, a, b, c);

                if (m.Equals(after))
                {
                    yield return opcode;
                }
            }
        }

        public static IReadOnlyDictionary<int, Opcodes> BuildOpcodeLookup(IEnumerable<Sample> samples)
        {
            var l = new Dictionary<int, Opcodes>();

            var opcodes = new HashSet<Opcodes>(AllOpcodes());

            while (opcodes.Any())
            {
                foreach (var sample in samples)
                {
                    var matching = FindMatchingOpcodes(
                        sample.Before,
                        sample.Instruction.A, sample.Instruction.B, sample.Instruction.C,
                        sample.After)
                        .Where(o => !l.ContainsValue(o));

                    if (matching.Count() == 1)
                    {
                        var opcode = matching.Single();

                        l[sample.Instruction.Opcode] = opcode;
                        opcodes.Remove(opcode);
                    }
                }
            }

            return l;
        }

        public static Machine ExecuteProgram(
            IEnumerable<Instruction> instructions,
            IReadOnlyDictionary<int, Opcodes> opcodeLookup)
        {
            var m = new Machine();

            foreach (var i in instructions)
            {
                m.Execute(opcodeLookup[i.Opcode], i.A, i.B, i.C);
            }

            return m;
        }
    }
}
