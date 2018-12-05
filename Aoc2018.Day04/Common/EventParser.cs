using Aoc2018.Day04.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Aoc2018.Day04.Common
{
    public static class EventParser
    {
        public static IEnumerable<Event> ParseInput(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                yield return ParseLine(line);
            }
        }

        private static readonly Regex _linePattern = new Regex(@"^\[(?<On>\d{4}-\d{2}-\d{2} \d{2}:\d{2})\]( Guard #(?<GuardId>\d+))? (?<EventType>.+)$");

        private const string DATE_TIME_FORMAT = @"yyyy-MM-dd HH:mm";

        private static Event ParseLine(string line)
        {
            var m = _linePattern.Match(line);
            if (!m.Success)
            {
                throw new ArgumentException($"invalid line: '{line}'", nameof(line));
            }

            if (!DateTime.TryParseExact(
                m.Groups[nameof(Event.On)].Value,
                DATE_TIME_FORMAT,
                null,
                DateTimeStyles.None,
                out var on))
            {
                throw new ArgumentException($"invalid date time: '{m.Groups[nameof(Event.On)].Value}'", nameof(line));
            }

            var guardId = 0;
            if (m.Groups[nameof(Event.GuardId)].Success &&
                !int.TryParse(
                    m.Groups[nameof(Event.GuardId)].Value,
                    out guardId))
            {
                throw new ArgumentException($"invalid guard id: '{m.Groups[nameof(Event.GuardId)].Value}'", nameof(line));
            }

            if (!Enum.TryParse<EventTypes>(
                m.Groups[nameof(Event.EventType)].Value.Replace(" ", ""),
                true,
                out var eventType))
            {
                throw new ArgumentException($"invalid event type: '{m.Groups[nameof(Event.EventType)].Value}'", nameof(line));
            }

            return new Event(on, guardId, eventType);
        }
    }
}
