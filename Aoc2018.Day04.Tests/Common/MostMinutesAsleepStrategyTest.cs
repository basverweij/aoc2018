using Aoc2018.Day04.Common;
using System.IO;
using System.Linq;
using Xunit;

namespace Aoc2018.Day04.Tests.Common
{
    public class MostMinutesAsleepStrategyTest
    {
        [Fact]
        public void TotalMinutesAsleepIsCorrect()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            var guard10Events = organizedEvents
                .Where(e => e.GuardId == 10);

            Assert.Equal(50, MostMinutesAsleepStrategy.TotalMinutesAsleep(guard10Events));

            var guard99Events = organizedEvents
                .Where(e => e.GuardId == 99);

            Assert.Equal(30, MostMinutesAsleepStrategy.TotalMinutesAsleep(guard99Events));
        }

        [Fact]
        public void SelectsGuardWithMostMinutesAsleep()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            Assert.Equal(10, MostMinutesAsleepStrategy.SelectGuard(organizedEvents));
        }

        [Fact]
        public void SelectMinuteWithHighestAsleepOccurrence()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            var guard10Events = organizedEvents
                .Where(e => e.GuardId == 10);

            Assert.Equal(24, MostMinutesAsleepStrategy.SelectMinute(guard10Events));

            var guard99Events = organizedEvents
                .Where(e => e.GuardId == 99);

            Assert.Equal(45, MostMinutesAsleepStrategy.SelectMinute(guard99Events));
        }

        [Fact]
        public void SelectsStrategyValue()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            Assert.Equal(240, MostMinutesAsleepStrategy.StrategyValue(organizedEvents));
        }
    }
}
