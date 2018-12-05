using Aoc2018.Day04.Common;
using System.IO;
using System.Linq;
using Xunit;

namespace Aoc2018.Day04.Tests.Common
{
    public class MostMinutesAsleepStrategyTest
    {
        private readonly MostMinutesAsleepStrategy _sut = new MostMinutesAsleepStrategy();

        [Fact]
        public void TotalMinutesAsleepIsCorrect()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            var guard10Events = organizedEvents
                .Where(e => e.GuardId == 10);

            Assert.Equal(50, _sut.TotalMinutesAsleep(guard10Events));

            var guard99Events = organizedEvents
                .Where(e => e.GuardId == 99);

            Assert.Equal(30, _sut.TotalMinutesAsleep(guard99Events));
        }

        [Fact]
        public void SelectsGuardWithMostMinutesAsleep()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            Assert.Equal(10, _sut.SelectGuard(organizedEvents));
        }

        [Fact]
        public void SelectMinuteWithHighestAsleepOccurrence()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            var guard10Events = organizedEvents
                .Where(e => e.GuardId == 10);

            Assert.Equal(24, _sut.SelectMinute(guard10Events));

            var guard99Events = organizedEvents
                .Where(e => e.GuardId == 99);

            Assert.Equal(45, _sut.SelectMinute(guard99Events));
        }

        [Fact]
        public void SelectsStrategyValue()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            Assert.Equal(240, _sut.StrategyValue(organizedEvents));
        }
    }
}
