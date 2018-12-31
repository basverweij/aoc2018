using Aoc2018.Day16.Instructions;
using Aoc2018.Day16.Machines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day16.Common
{
    public static class MachineUtil
    {
        public static IEnumerable<Opcodes> FindMatchingOpcodes(Machine before, int a, int b, int c, Machine after)
        {
            foreach (var opcode in Enum.GetValues(typeof(Opcodes)).Cast<Opcodes>())
            {
                var m = new Machine(before.Registers);

                m.Execute(opcode, a, b, c);

                if (m.Equals(after))
                {
                    yield return opcode;
                }
            }
        }
    }
}
