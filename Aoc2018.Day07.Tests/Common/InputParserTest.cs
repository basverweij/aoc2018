using Aoc2018.Day07.Common;
using Aoc2018.Day07.Instructions;
using Xunit;

namespace Aoc2018.Day07.Tests.Common
{
    public class InputParserTest
    {
        [Fact]
        public void ParsesInput()
        {
            var input = new string[]
            {
                "Step C must be finished before step F can begin.",
                "Step C must be finished before step A can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin.",
            };

            var expected = new Instruction[]
            {
                new Instruction('C', 'F'),
                new Instruction('C', 'A'),
                new Instruction('A', 'B'),
                new Instruction('A', 'D'),
                new Instruction('B', 'E'),
                new Instruction('D', 'E'),
                new Instruction('F', 'E'),
            };

            Assert.Equal(expected, InputParser.Parse(input));
        }
    }
}
