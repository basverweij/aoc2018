using Aoc2018.Day16.Common;
using Aoc2018.Day16.Machines;
using System.Linq;
using Xunit;

namespace Aoc2018.Day16.Tests.Common
{
    public class MachineUtilTest
    {
        [Fact]
        public void FindsMatchingOpcodes()
        {
            var before = new Machine(3, 2, 1, 1);

            var after = new Machine(3, 2, 2, 1);

            Assert.Equal(
                3,
                MachineUtil
                    .FindMatchingOpcodes(before, 2, 1, 2, after)
                    .Count());
        }
    }
}
