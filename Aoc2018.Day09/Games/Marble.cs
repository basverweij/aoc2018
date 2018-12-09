namespace Aoc2018.Day09.Games
{
    public class Marble
    {
        public long Value { get; set; }

        public Marble Next { get; set; }

        public Marble Previous { get; set; }

        public Marble(long value)
        {
            Value = value;
        }
    }
}