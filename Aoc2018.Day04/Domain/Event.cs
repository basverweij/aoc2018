using System;

namespace Aoc2018.Day04.Domain
{
    public class Event
    {
        public Event(DateTime on, int guardId, EventTypes eventType)
        {
            On = on;
            GuardId = guardId;
            EventType = eventType;
        }

        public DateTime On { get; }

        public int GuardId { get; internal set; }

        public EventTypes EventType { get; }

        public override string ToString()
        {
            return $"[{On:yyyy-MM-dd HH:mm}] #{GuardId} {EventType}";
        }
    }
}
