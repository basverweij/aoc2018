using Aoc2018.Day16.Common;
using Aoc2018.Day16.Instructions;
using Aoc2018.Day16.Machines;
using System.Linq;
using Xunit;

namespace Aoc2018.Day16.Tests.Common
{
    public class InputParserTest
    {
        [Fact]
        public void ParsesSamples()
        {
            var input = new string[]
            {
                "Before: [3, 2, 1, 1]",
                "9 2 1 2",
                "After:  [3, 2, 2, 1]",
                "",
            };

            var sample = InputParser
                .ParseSamples(input)
                .Single();

            Assert.Equal(new Machine(3, 2, 1, 1), sample.Before);

            Assert.Equal(new Instruction(9, 2, 1, 2), sample.Instruction);

            Assert.Equal(new Machine(3, 2, 2, 1), sample.After);
        }
    }
}
