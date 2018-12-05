using Aoc2018.Day04.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day04.Common
{
    public static class MostMinutesAsleepStrategy
    {
        public static int StrategyValue(IReadOnlyList<Event> events)
        {
            int guardId = SelectGuard(events);

            var guardEvents = events.Where(e => e.GuardId == guardId);

            int minute = SelectMinute(guardEvents);

            return guardId * minute;
        }

        public static int SelectMinute(IEnumerable<Event> guardEvents)
        {
            TotalMinutesAsleep(guardEvents, out var minutes);

            var max = minutes.Max();

            return Array.IndexOf(minutes, max);
        }

        public static int SelectGuard(IReadOnlyList<Event> events)
        {
            return events
                .GroupBy(e => e.GuardId)
                .OrderByDescending(g => TotalMinutesAsleep(g))
                .First()
                .Key;
        }

        public static int TotalMinutesAsleep(IEnumerable<Event> g)
        {
            return TotalMinutesAsleep(g, out var minutes);
        }

        public static int TotalMinutesAsleep(IEnumerable<Event> g, out int[] minutes)
        {
            var totalMinutes = 0;
            minutes = new int[60];

            var isAsleep = false;
            var startMinute = 0;

            foreach (var e in g)
            {
                var currentMinute = e.On.Hour > 1 ? 0 : e.On.Minute;

                switch (e.EventType)
                {
                    case EventTypes.BeginsShift:
                        isAsleep = false;
                        break;

                    case EventTypes.FallsAsleep:
                        if (isAsleep)
                        {
                            throw new InvalidOperationException($"already asleep when '{e}'");
                        }

                        isAsleep = true;
                        startMinute = currentMinute;
                        break;

                    case EventTypes.WakesUp:
                        if (!isAsleep)
                        {
                            throw new InvalidOperationException($"already awake when '{e}'");
                        }

                        isAsleep = false;
                        totalMinutes += currentMinute - startMinute;

                        for (var i = startMinute; i < currentMinute; i++)
                        {
                            minutes[i]++;
                        }

                        break;
                }
            }

            return totalMinutes;
        }
    }
}
