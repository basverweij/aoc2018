using Aoc2018.Day04.Common;
using System.IO;
using System.Linq;
using Xunit;

namespace Aoc2018.Day04.Tests.Common
{
    public class EventParserTest
    {
        [Fact]
        public void ParsesInput()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            Assert.Equal(17, events.Count());
        }
    }
}
