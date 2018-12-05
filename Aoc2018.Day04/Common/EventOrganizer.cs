using Aoc2018.Day04.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Day04.Common
{
    public static class EventOrganizer
    {
        public static IReadOnlyList<Event> Organize(IEnumerable<Event> events)
        {
            var sortedEvents = events
                .OrderBy(e => e.On)
                .ToList();

            if (sortedEvents[0].GuardId == 0)
            {
                throw new ArgumentException($"first event is missing guard id: {sortedEvents[0]}", nameof(events));
            }

            var guardId = 0;
            foreach (var e in sortedEvents)
            {
                if (e.GuardId != 0)
                {
                    guardId = e.GuardId;

                    continue;
                }

                e.GuardId = guardId;
            }

            return sortedEvents;
        }
    }
}
