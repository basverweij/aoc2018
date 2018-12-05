using Aoc2018.Day04.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day04.Common
{
    public abstract class AbstractMinutesAsleepBasedStrategy
    {
        public int SelectMinute(IEnumerable<Event> guardEvents)
        {
            TotalMinutesAsleep(guardEvents, out var minutes);

            var max = minutes.Max();

            return Array.IndexOf(minutes, max);
        }

        public int TotalMinutesAsleep(IEnumerable<Event> g)
        {
            return TotalMinutesAsleep(g, out var minutes);
        }

        public int TotalMinutesAsleep(IEnumerable<Event> g, out int[] minutes)
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
