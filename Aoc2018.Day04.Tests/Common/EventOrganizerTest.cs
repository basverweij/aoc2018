using Aoc2018.Day04.Common;
using System.IO;
using System.Linq;
using Xunit;

namespace Aoc2018.Day04.Tests.Common
{
    public class EventOrganizerTest
    {
        [Fact]
        public void OrganizesInput()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            Assert.Equal(17, organizedEvents.Count());
        }
    }
}
