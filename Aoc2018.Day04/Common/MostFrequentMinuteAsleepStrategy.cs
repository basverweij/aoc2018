using Aoc2018.Day04.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day04.Common
{
    public class MostFrequentMinuteAsleepStrategy :
        AbstractMinutesAsleepBasedStrategy
    {
        public int StrategyValue(IReadOnlyList<Event> events)
        {
            int guardId = SelectGuard(events);

            var guardEvents = events.Where(e => e.GuardId == guardId);

            int minute = SelectMinute(guardEvents);

            return guardId * minute;
        }

        public int SelectGuard(IReadOnlyList<Event> events)
        {
            return events
                .GroupBy(e => e.GuardId)
                .OrderByDescending(g =>
                {
                    TotalMinutesAsleep(g, out var minutes);

                    return minutes.Max();
                })
                .First()
                .Key;
        }
    }
}
