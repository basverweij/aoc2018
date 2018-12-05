using Aoc2018.Day04.Common;
using System.IO;
using Xunit;

namespace Aoc2018.Day04.Tests.Common
{
    public class MostFrequentMinuteAsleepStrategyTest
    {
        private readonly MostFrequentMinuteAsleepStrategy _sut = new MostFrequentMinuteAsleepStrategy();

        [Fact]
        public void SelectsGuardWithMostFrequentMinuteAsleep()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            Assert.Equal(99, _sut.SelectGuard(organizedEvents));
        }

        [Fact]
        public void SelectsStrategyValue()
        {
            var input = File.ReadAllLines("input.txt");

            var events = EventParser.ParseInput(input);

            var organizedEvents = EventOrganizer.Organize(events);

            Assert.Equal(4455, _sut.StrategyValue(organizedEvents));
        }
    }
}
