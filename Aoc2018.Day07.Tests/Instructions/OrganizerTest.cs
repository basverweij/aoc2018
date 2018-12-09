using Aoc2018.Day07.Instructions;
using Xunit;

namespace Aoc2018.Day07.Tests.Instructions
{
    public class OrganizerTest
    {
        [Fact]
        public void OrganizesInstructions()
        {
            var instructions = new Instruction[]
            {
                new Instruction('C', 'F'),
                new Instruction('C', 'A'),
                new Instruction('A', 'B'),
                new Instruction('A', 'D'),
                new Instruction('B', 'E'),
                new Instruction('D', 'E'),
                new Instruction('F', 'E'),
            };

            var expected = "CABDFE";

            Assert.Equal(expected, Organizer.OrganizeInstructions(instructions));
        }
    }
}
